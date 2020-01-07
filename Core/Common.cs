using System;
using System.Collections.Generic;
using System.Linq;
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

        public static long NewFriends { get; set; } = 0;

        public static MainWindow MainWindow = null;
    }
}
