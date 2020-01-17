using Core.Request;
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
        /// 酷Q接口的封装类
        /// </summary>
        public static CQApi Api { get; set; }

        /// <summary>
        ///  酷Q日志的封装类
        /// </summary>
        public static CQLog Log { get; set; }

        /// <summary>
        /// 好友列表扩展
        /// </summary>
        public static FriendRequest Friends { get; set; }

        /// <summary>
        /// QQ会员资料
        /// </summary>
        public static VipInfo VipInfo { get; set; }

        /// <summary>
        /// QQ图标
        /// </summary>
        public static Icon Icon { get; set; }

        /// <summary>
        /// 群公告
        /// </summary>
        public static GroupRequest Group { get; set; }

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
