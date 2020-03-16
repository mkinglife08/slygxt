using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using EMR.Data.Models;
using EMR.Data;

namespace EMR.Common
{
   public class msgHub : Hub
    {
        public void Send(string[] userId, string mType, string id, string msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<msgHub>();
            for (int i = 0; i < userId.Length; i++)
            {
                context.Clients.User(userId[i]).getMsg(mType, id,  msg);
            }
        }
        public void SendAll(string mType, string id,  string msg)
        {
            //Clients.User(userId).send(message);
            var context = GlobalHost.ConnectionManager.GetHubContext<msgHub>();

            context.Clients.All.getMsg(mType, id, msg);

        }
        public void SendGroup(string groupName, string mType, string id,string msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<msgHub>();
            context.Clients.Group(groupName).getMsg(mType, id, msg);
        }
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }

    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            var userId = request.QueryString["UserId"];
            return userId.ToString();
        }
        public string GetGroup(IRequest request)
        {
            var DpetID = request.QueryString["DpetID"];
          //  GI_UserInfo user= EntityOperate<GI_UserInfo>.GetEntityById(userId, "UserId");
            return DpetID.ToString();
        }
    }

}
