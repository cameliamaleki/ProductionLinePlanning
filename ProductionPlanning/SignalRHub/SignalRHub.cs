using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CRM.SignalRHub
{
    public class SignalRMainHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
            Clients.All.ShowPhoneCall(name, message);
        }

        public void SendPhoeneNumber(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void SendMessage(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }


    }
}
namespace CRM.SignalRNotification
{

    public class NotificationSender
    {
        public void SendPhoneCallIn(string name, string message, string phonenumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CRM.SignalRHub.SignalRMainHub>();
            hubContext.Clients.All.ShowPhoneCall(name, message, phonenumber);
        }
        public void SendCentraSystemPhoneCallIn(string name, string message, string phonenumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CRM.SignalRHub.SignalRMainHub>();
            hubContext.Clients.All.SendCentraSystemPhoneCallIn(name, message, phonenumber);
        }
        public void SendCentraSystemPhoneCallInAnswerCall(string phonenumber)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CRM.SignalRHub.SignalRMainHub>();
            hubContext.Clients.All.SendCentraSystemPhoneCallInAnswerCall(phonenumber);


        }
    }
}