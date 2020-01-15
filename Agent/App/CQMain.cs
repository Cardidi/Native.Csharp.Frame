using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Native.Csharp.Sdk.Cqp.Interface;
using Core;

namespace Native.Csharp.App
{
	/// <summary>
	/// 酷Q应用主入口类
	/// </summary>
	public static class CQMain
	{
		/// <summary>
		/// 在应用被加载时将调用此方法进行事件注册, 请在此方法里向 <see cref="IUnityContainer"/> 容器中注册需要使用的事件
		/// </summary>
		/// <param name="container">用于注册的 IOC 容器 </param>
		public static void Register (IUnityContainer container)
		{
			container.RegisterType<IPrivateMessage, Event_Message>("私聊消息处理");
			container.RegisterType<IGroupMessage, Event_Message>("群消息处理");
			container.RegisterType<IDiscussMessage, Event_Message>("讨论组消息处理");

			container.RegisterType<ICQStartup, Event_App>("酷Q启动事件");
			container.RegisterType<ICQExit, Event_App>("酷Q关闭事件");
			container.RegisterType<IAppEnable, Event_App>("应用已被启用");
			container.RegisterType<IAppDisable, Event_App>("应用将被停用");

			container.RegisterType<IFriendAdd, Event_Friend>("好友已添加事件处理");
			container.RegisterType<IFriendAddRequest, Event_Friend>("好友添加请求处理");

			container.RegisterType<IGroupAddRequest, Event_Group>("群添加请求处理");
			container.RegisterType<IGroupBanSpeak, Event_Group>("群禁言事件处理");
			container.RegisterType<IGroupManageChange, Event_Group>("群管理变动事件处理");
			container.RegisterType<IGroupMemberDecrease, Event_Group>("群成员减少事件处理");

			///酷Q:受邀请直接被拉进群时触发的群成员增加事件内QQ号码为0
			///SDK:由於QQID校验机制，当发生受邀请直接被拉进群时会直接报错(QQ号码为0)。
			///目前，请慎用IGroupMemberIncrease。
			
			//container.RegisterType<IGroupMemberIncrease, Event_Group>("群成员增加事件处理");

			container.RegisterType<IGroupUpload, Event_Group>("群文件上传事件处理");

			container.RegisterType<IMenuCall, Event_Menu>("应用设置");
			container.RegisterType<IStatusUpdate, Event_Status>("新加好友累计");

		}
	}
}
