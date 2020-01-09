using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using Core.Action;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using UI.Model;

namespace Core
{
    public class Event_Message : IGroupMessage, IPrivateMessage, IDiscussMessage
    {
        public void DiscussMessage(object sender, CQDiscussMessageEventArgs e)
        {

        }

        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            //绑定数据同步
            BindingOperations.EnableCollectionSynchronization(ViewModel.MainInstance.GroupMessages, ViewModel.MainInstance.SyncLock);

            ViewModel.MainInstance.GroupMessages.Add(new Message()
            {
                Qq = e.FromQQ.Id,
                GroupId = e.FromGroup.Id,
                Content = e.Message.ToSendString(),
                DisplayName = e.CQApi.GetGroupMemberInfo(e.FromGroup, e.FromQQ).Nick,
                GroupName = e.CQApi.GetGroupInfo(e.FromGroup).Name,
            });

            //沒有啟用插件时,不处理其他服务
            if (Common.IsRunning == false) { return; }

            //判断收到的消息中是否有被艾特
            if (e.Message.CQCodes.Any(a => a.Function == Native.Csharp.Sdk.Cqp.Enum.CQFunction.At && a.Items["qq"] == e.CQApi.GetLoginQQ().Id.ToString()) == false) { return; }

            //价值100亿AI的核心
            if (e.Message.OriginalMessage.Contains("?") || e.Message.OriginalMessage.Contains("？"))
            {
                //阻断事件，不再将事件传递给优先级更低的插件
                e.Handler = true;
                //将消息发送到群内
                e.CQApi.SendGroupMessage(e.FromGroup, e.Message.OriginalMessage.Replace("?", "。").Replace("？", "。"));
            }

            //使用 "/撤回 {信息倒数条数}"
            if (e.Message.OriginalMessage.Contains("/撤回"))
            {
                string digit = Regex.Match(e.Message.OriginalMessage, @"\d+").Value;
                if (int.TryParse(digit, out int index))
                {
                    RemoveMessage.RemoveByGroupIdWithIndex(e.FromGroup.Id, index);
                }
            }

            //下载消息中的图片
            ReceiveImage.ReceiveAllImageFromMessage(e.Message);
        }

        public void PrivateMessage(object sender, CQPrivateMessageEventArgs e)
        {

        }
    }
}
