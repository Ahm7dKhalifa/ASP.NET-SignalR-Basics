using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatDemo_MicrosoftDocs.SignalR_Backend
{
    public class ChatHub : Hub
    {
        
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage javascript method to update clients.
            Clients.All.addNewMessageToPage(name, message);
            
        }
        
    }
}