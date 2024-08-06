using DarkMessages.models.Friends;
using DarkMessages.models.Message;
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

        public void ConsultOnlineFriends(rpConsultFriends rpConsultFriends) 
        {
            Clients.All.SendAsync("ReceivieOnlineFriends", rpConsultFriends);
        }

        
    }
}
