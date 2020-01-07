using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Model;

namespace Core
{
    public class Event_App : ICQStartup, ICQExit, IAppEnable, IAppDisable
    {
        public void AppDisable(object sender, CQAppDisableEventArgs e)
        {
            Common.IsRunning = false;
        }

        public void AppEnable(object sender, CQAppEnableEventArgs e)
        {
            Common.IsRunning = true;
        }

        public void CQExit(object sender, CQExitEventArgs e)
        {

        }

        public void CQStartup(object sender, CQStartupEventArgs e)
        {
            ViewModel.MainInstance.Api = e.CQApi;
            ViewModel.MainInstance.Log = e.CQLog;
        }
    }
}
