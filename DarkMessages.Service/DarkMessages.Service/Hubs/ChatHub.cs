using DarkMessages.models.Friends;
using DarkMessages.models.Groups;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
using DarkMessages.Service.Objects;
using Microsoft.AspNetCore.SignalR;

namespace DarkMessages.Service.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {

        public void ConsultMessages(rpConsultMessages rpConsultMessages)
        {
            Clients.All.SendAsync("ReceiveMessages", rpConsultMessages);
        }

        //public void ConsultFriendsUpdateds(rpConsultFriends rpConsultFriends) 
        //{
        //    Clients.All.SendAsync("FriendsUpdateds", rpConsultFriends);
        //}

        public void ConsultOnlineFriends(rpConsultFriends rpConsultFriends) 
        {
            Clients.All.SendAsync("ReceivieOnlineFriends", rpConsultFriends);
        }

        public void ConsultGroupMessages(rpConsultGroupMessages rpConsultGroupMessages) 
        {
            Clients.All.SendAsync("ReceiveGroupMessages", rpConsultGroupMessages);
        }

        public void ConsultNotifications(object obj)
        {
            Clients.All.SendAsync("ReceiveNotifications", obj);
        }

        public void ConsultUsersOnlineStatus(rpMantSession rpMantSession)
        {
            Clients.All.SendAsync("ReceiveUsersOnlineStatus", rpMantSession);
        }




    }
}
