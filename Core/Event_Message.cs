using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Core
{
    public class Event_Message : IGroupMessage, IPrivateMessage, IDiscussMessage
    {
        public void DiscussMessage(object sender, CQDiscussMessageEventArgs e)
        {

        }

        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            if (Common.IsRunning == false) { return; }
            if(e.Message.CQCodes.Any(a=> a.Function == Native.Csharp.Sdk.Cqp.Enum.CQFunction.At && a.Items["qq"] == e.CQApi.GetLoginQQ().ToString()))
            {

                if(e.Message.OriginalMessage.Contains("?")|| e.Message.OriginalMessage.Contains("？"))
                {
                    e.CQApi.SendGroupMessage(e.FromGroup, e.Message.OriginalMessage.Replace("?", "。").Replace("？", "。"));
                }
            }

            if (e.Message.CQCodes.Any(a => a.Function == Native.Csharp.Sdk.Cqp.Enum.CQFunction.Image))
            {
                string path = e.Message.ReceiveImage(0);
                e.CQLog.Debug("保存图片", path);
            }
        }

        public void PrivateMessage(object sender, CQPrivateMessageEventArgs e)
        {

        }
    }
}
