using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using Native.Csharp.Tool.IniConfig.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Model;
using Core.Service;
using Nancy.Hosting.Wcf;
using System.ServiceModel.Web;
using Core.Helper;

namespace Core
{
    public class Event_App : ICQStartup, ICQExit, IAppEnable, IAppDisable
    {
        public void AppDisable(object sender, CQAppDisableEventArgs e)
        {
            Common.IsRunning = false;
            if(Common.WebServiceHost.State == System.ServiceModel.CommunicationState.Opening || Common.WebServiceHost.State == System.ServiceModel.CommunicationState.Opened)
            {
                Common.WebServiceHost.Close();
            }
        }

        public void AppEnable(object sender, CQAppEnableEventArgs e)
        {
            Common.IsRunning = true;
            try
            {
                Common.WebServiceHost.Open();
            }
            catch (System.ServiceModel.AddressAccessDeniedException)
            {
                e.CQLog.Warning("WCF服务失效", "需要以管理员权限运行酷Q方可启用WCF服务");
            }
        }

        public void CQExit(object sender, CQExitEventArgs e)
        {
            Common.WebServiceHost.Abort();
        }

        public void CQStartup(object sender, CQStartupEventArgs e)
        {
            Common.CoolQDatabase = new CQDataBase(e.CQApi.GetLoginQQ().Id);

            Common.WebServiceHostPort = TCPHelper.GetAvailablePort(80);
            Common.WebServiceHost = new WebServiceHost(new NancyWcfGenericService(new Startup.NancyBootstrapper()), new Uri($"http://localhost:{Common.WebServiceHostPort}"));
            Common.WebServiceHost.AddServiceEndpoint(typeof(NancyWcfGenericService), new Startup.NancyWebHttpBinding(), "");

            e.CQLog.Info("WCF服务端口", $"{Common.WebServiceHostPort}");

            Common.Api = e.CQApi;
            Common.Log = e.CQLog;
            Common.Friend = new Request.FriendList(e.CQApi,e.CQLog);

            ViewModel.MainInstance.Api = e.CQApi;
            ViewModel.MainInstance.Log = e.CQLog;
            ViewModel.MainInstance.UISettingPath = Path.Combine(e.CQApi.AppDirectory, "UISetting.ini");
        }
    }
}
