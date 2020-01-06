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

        }

        public void GroupBanSpeak(object sender, CQGroupBanSpeakEventArgs e)
        {

        }

        public void GroupManageChange(object sender, CQGroupManageChangeEventArgs e)
        {

        }

        public void GroupMemberDecrease(object sender, CQGroupMemberDecreaseEventArgs e)
        {

        }

        public void GroupMemberIncrease(object sender, CQGroupMemberIncreaseEventArgs e)
        {

        }

        public void GroupUpload(object sender, CQGroupUploadEventArgs e)
        {

        }
    }
}
