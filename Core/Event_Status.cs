using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Event_Status : IStatusUpdate
    {
        public CQFloatWindow StatusUpdate(object sender, CQStatusUpdateEventArgs e)
        {
            return new CQFloatWindow()
            {
                TextColor = Native.Csharp.Sdk.Cqp.Enum.CQFloatWindowColors.Green,
                Unit = "人",
                Value = Common.NewFriends
            };
        }
    }
}
