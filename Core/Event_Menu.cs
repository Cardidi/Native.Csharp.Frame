using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using System.Windows;
using System.Reflection;

namespace Core
{
    public class Event_Menu : IMenuCall
    {

        public void MenuCall(object sender, CQMenuCallEventArgs e)
        {
            e.CQLog.Debug("菜单点击事件", $"打开介面-{e.Name}");
            OpenWpf();
        }

        public void OpenWpf()
        {
            if (Common.MainWindow != null)
            {
                var propertyInfo = typeof(MainWindow).GetProperty("IsDisposed", BindingFlags.NonPublic | BindingFlags.Instance);
                if (!(bool)propertyInfo.GetValue(Common.MainWindow, null))
                {
                    Common.MainWindow.Focus();
                    return;
                }
            }
            Common.MainWindow = new MainWindow();
            Common.MainWindow.Show();
        }
    }
}
