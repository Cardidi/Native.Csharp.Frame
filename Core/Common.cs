using Core.Service;
using Native.Csharp.Sdk.Cqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace Core
{
    public static class Common
    {
        /// <summary>
        /// 获取或设置当前 App 是否处于运行状态
        /// </summary>
        public static bool IsRunning { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public static CQApi Api { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static CQLog Log { get; set; }

        /// <summary>
        /// 新加入的朋友数
        /// </summary>
        public static long NewFriends { get; set; } = 0;

        /// <summary>
        /// UI窗口
        /// </summary>
        public static MainWindow MainWindow = null;

        /// <summary>
        /// 酷Q内部的数据库
        /// </summary>
        public static CQDataBase CoolQDatabase { get; set; }

        /// <summary>
        /// WCF服务
        /// </summary>
        public static WebServiceHost WebServiceHost { get; set; }

        /// <summary>
        /// WCF服务端口
        /// </summary>
        public static int WebServiceHostPort { get; set; }

        /// <summary>
        /// 悬浮窗使用时长
        /// </summary>
        public static long UpTime { get; set; }


    }
}
