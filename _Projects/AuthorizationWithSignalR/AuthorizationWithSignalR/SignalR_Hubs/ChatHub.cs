using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace AuthorizationWithSignalR.SignalR_Hubs
{
    [Authorize(Roles = "Employee")]
    public class ChatHub : Hub
    {

        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public void Send(string who,string message)
        {
            //who  ==> reciver user
            //name ==> current user or sender user
            string name = Context.User.Identity.Name;

            if(who == "All")
            {
                Clients.All.addChatMessage(name + ": " + message);
            }
            else
            {
                foreach (var connectionId in _connections.GetConnections(who))
                {
                    Clients.Client(connectionId).addChatMessage(name + ": " + message);
                }
            }   
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        
    }
}