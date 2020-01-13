using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Event_Group : IGroupAddRequest, IGroupBanSpeak, IGroupManageChange, IGroupMemberDecrease, IGroupMemberIncrease, IGroupUpload
    {
        public void GroupAddRequest(object sender, CQGroupAddRequestEventArgs e)
        {
            if (e.SubType == Native.Csharp.Sdk.Cqp.Enum.CQGroupAddRequestType.RobotBeInviteAddGroup)
            {
                e.CQLog.Debug("进群申请", $"机器人被邀请进群 {e.FromGroup}");
            }
            else
            {
                e.CQLog.Debug("进群申请", $"申请人 {e.FromQQ} 进群 {e.FromGroup}");
            }
        }

        public void GroupBanSpeak(object sender, CQGroupBanSpeakEventArgs e)
        {
            if (e.SubType == Native.Csharp.Sdk.Cqp.Enum.CQGroupBanSpeakType.SetBanSpeak)
            {
                e.CQLog.Debug("群禁言", $"{e.FromQQ} 禁言了 {e.BeingOperateQQ} 在群 {e.FromGroup}");
            }
            else
            {
                e.CQLog.Debug("群禁言", $"{e.FromQQ} 解除了 {e.BeingOperateQQ} 的禁言在群 {e.FromGroup}");
            }
        }

        public void GroupManageChange(object sender, CQGroupManageChangeEventArgs e)
        {
            if (e.SubType == Native.Csharp.Sdk.Cqp.Enum.CQGroupManageChangeType.SetManage)
            {
                e.CQLog.Debug("群管理", $"{e.BeingOperateQQ} 成为管理员 在群{e.FromGroup}");
            }
            else
            {
                e.CQLog.Debug("群管理", $"{e.BeingOperateQQ} 失去管理员权限 在群{e.FromGroup}");
            }
        }

        public void GroupMemberDecrease(object sender, CQGroupMemberDecreaseEventArgs e)
        {
            if (e.SubType == Native.Csharp.Sdk.Cqp.Enum.CQGroupMemberDecreaseType.RemoveGroup)
            {
                e.CQLog.Debug("踢出群", $"{e.FromQQ} 把 {e.BeingOperateQQ} 踢出了群 {e.FromGroup}");
            }
            else
            {
                e.CQLog.Debug("退群", $"{e.BeingOperateQQ} 退出了群 {e.FromGroup}");
            }
        }

        public void GroupMemberIncrease(object sender, CQGroupMemberIncreaseEventArgs e)
        {
            if (e.SubType == Native.Csharp.Sdk.Cqp.Enum.CQGroupMemberIncreaseType.Invite)
            {
                e.CQLog.Debug("邀请进群", $"{e.FromQQ} 邀请 {e.BeingOperateQQ} 加入了群 {e.FromGroup}.");
            }
            else
            {
                e.CQLog.Debug("自主进群", $"{e.FromQQ}加入了群");
            }
        }

        public void GroupUpload(object sender, CQGroupUploadEventArgs e)
        {
            e.CQLog.Debug("新群文件", $"{e.FromQQ} 上传了 {e.FileInfo.FileName}({e.FileInfo.FileSize}) 到群 {e.FromGroup}");
        }
    }
}
