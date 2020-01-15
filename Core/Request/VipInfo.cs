using Native.Csharp.Sdk.Cqp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class VipInfo
    {
        static readonly RestClient restClientMobile = new RestClient("https://h5.vip.qq.com");
        static readonly string userAgentMobile = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16A5288q QQ/6.5.5.0 TIM/2.2.5.401 V1_IPH_SQ_6.5.5_1_TIM_D Pixel/750 Core/UIWebView Device/Apple(iPhone 6s) NetType/WIFI";
        
        private int Gtk { get; set; }
        private long Login_Qq { get; set; }
        private CQLog Log { get; set; }

        public VipInfo(CQApi api, CQLog log)
        {
            Log = log;
            Gtk = api.GetCsrfToken();
            Login_Qq = api.GetLoginQQId();
            var CookieContainer = new System.Net.CookieContainer();

            CookieContainer.SetCookies(restClientMobile.BaseUrl, api.GetCookies(restClientMobile.BaseUrl.AbsoluteUri).Replace(";", ","));

            restClientMobile.UserAgent = userAgentMobile;
            restClientMobile.CookieContainer = CookieContainer;
            restClientMobile.Encoding = Encoding.GetEncoding("gb2312");
            restClientMobile.AddDefaultHeader("Content-Type", "text/html;charset=gb2312");

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public VipInfo GetVipInfo(long QqId)
        {
            string url = $"/p/mc/cardv2/other?platform=1&qq={QqId}&adtag=geren&aid=mvip.pingtai.mobileqq.androidziliaoka.fromqita";

            RestRequest request = new RestRequest(url);
            var response = restClientMobile.Execute(request);

            if (response?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //TODO
            }
            return null;
        }

    }
}
