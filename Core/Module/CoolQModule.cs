using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Module
{
    public class CoolQModule : NancyModule
    {
        public CoolQModule()
        {
            Post["/cqapi/SendGroupMessage"] = x =>
            {
                var para = this.Bind<ApiSendMessage>();

                int flag = Common.Api.SendGroupMessage(para.Id, para.Message);
                return this.Response.AsJson(flag, flag > 0 ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            };

            Post["/cqapi/SendPrivateMessage"] = x =>
            {
                var para = this.Bind<ApiSendMessage>();

                int flag = Common.Api.SendPrivateMessage(para.Id, para.Message);
                return this.Response.AsJson(flag, flag > 0 ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            };

            Post["/cqapi/SendDiscussMessage"] = x =>
            {
                var para = this.Bind<ApiSendMessage>();

                int flag = Common.Api.SendDiscussMessage(para.Id, para.Message);
                return this.Response.AsJson(flag, flag > 0 ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            };

            Get["/cqapi/GetLoginQQ"] = x =>
            {
                return this.Response.AsJson(Common.Api.GetLoginQQ());
            };
            Get["/cqapi/GetLoginQQId"] = x =>
            {
                return this.Response.AsJson(Common.Api.GetLoginQQId());
            };
            Get["/cqapi/GetLoginNick"] = x =>
            {
                return this.Response.AsJson(Common.Api.GetLoginNick());
            };
            Get["/cqapi/GetFriendList"] = x =>
            {
                return this.Response.AsJson(Common.Api.GetFriendList());
            };
            Get["/cqapi/GetGroupList"] = x =>
            {
                return this.Response.AsJson(Common.Api.GetGroupList());
            };

            Post["/cqapi/GetStrangerInfo"] = x =>
            {
                var para = this.Bind<ApiGetStrangerInfo>();
                return this.Response.AsJson(Common.Api.GetStrangerInfo(para.QqId));
            };
            Post["/cqapi/GetGroupMemberInfo"] = x =>
            {
                var para = this.Bind<ApiGetGroupMemberInfo>();
                return this.Response.AsJson(Common.Api.GetGroupMemberInfo(para.GroupId, para.QqId));
            };
            Post["/cqapi/GetGroupMemberList"] = x =>
            {
                var para = this.Bind<ApiGetGroupMemberList>();
                return this.Response.AsJson(Common.Api.GetGroupMemberList(para.GroupId));
            };
        }
    }

    public class ApiSendMessage
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }

    public class ApiGetGroupMemberList
    {
        public long GroupId { get; set; }
    }

    public class ApiGetGroupMemberInfo
    {
        public long GroupId { get; set; }
        public long QqId { get; set; }
    }

    public class ApiGetStrangerInfo
    {
        public long QqId { get; set; }
    }

}
