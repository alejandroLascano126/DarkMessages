using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DarkMessages.models.Login;
using DarkMessages.Service.Objects;
using DarkMessages.models.SignUp;
using DarkMessages.models.Message;
using DarkMessages.models.Friends;
using DarkMessages.Service.Hub;
using Microsoft.AspNetCore.SignalR;
using DarkMessages.models.Usuarios;
using DarkMessages.models.Groups;
using System.Net.NetworkInformation;
using DarkMessages.models.Chats;
using DarkMessages.models.Session;
using DarkMessages.models.Notifications;
using DarkMessages.models.Token;

namespace DarkMessages.Service.Controllers
{
    [Route("api/darkmsgs")]
    [ApiController]
    public class DarkMessagesController : ControllerBase
    {
        UserObj userObj = new UserObj();
        MessageObj messageObj = new MessageObj();
        GroupObj groupObj = new GroupObj();
        ChatObj chatObj = new ChatObj();
        SessionObj sessionObj = new SessionObj();   
        NotificationObj notificationObj = new NotificationObj();
        TokenObj tokenObj = new TokenObj();
        private readonly IHubContext<ChatHub> _hubContext;

        public DarkMessagesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpPost("ValidateSecurityCode")]
        public async Task<rpValidateSecurityCode> LoginSecurityCode(rqValidateSecurityCode rq)
        {
            rpValidateSecurityCode rp = new rpValidateSecurityCode();
            rp = await userObj.ValidateSecurityCodeAsync(rq);
            return rp;
        }

        [HttpPost("ValidaUsernamePassword")]
        public async Task<rpLogin> ValidaUsernamePasswordAsync(rqLogin rq)
        {
            rpLogin rp = new rpLogin();
            rp = await userObj.LoginUserAsync(rq);
            return rp;
        }

        [HttpPost("ResendSecurityCode")]
        public async Task<rpLogin> ResendSecurityCode(rqLogin rq)
        {
            rpLogin rp = new rpLogin();
            rp = await userObj.generateSecurityCode(rq);
            return rp;
        }

        [HttpPost("RegisterUser")]
        public async Task<rpSignUp> RegisterUser(rqSignUp rq)
        {
            rpSignUp rp = new rpSignUp();
            rp = await userObj.registerUserAsync(rq);
            return rp;
        }

        [HttpPost("insertMessage")]
        public async Task<rpInsertMessage> insertMessage(rqInsertMessage rq)
        {
            rpInsertMessage rp = new rpInsertMessage();
            rp = await messageObj.insertMessage(rq);
            if (rp.success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessages", rp);
            }
            return rp;
        }

        [HttpPost("consultMessages")]
        public async Task<rpConsultMessages> consultMessages(rqConsultMessages rq)
        {
            rpConsultMessages rp = new rpConsultMessages();
            rp = await messageObj.consultMessages(rq);
            return rp;
        }


        [HttpPost("consultFriends")]
        public async Task<rpConsultFriends> consultFriends(rqConsultFriends rq)
        {
            rpConsultFriends rp = new rpConsultFriends();
            rp = await userObj.consultFriends(rq);
            return rp;
        }

        [HttpPost("countMessages")]
        public async Task<rpCountMessages> countMessages(rqCountMessages rq)
        {
            rpCountMessages rp = new rpCountMessages();
            rp = await messageObj.countMessages(rq);
            return rp;

        }

        [HttpPost("filterUsers")]
        public async Task<rpUserQuery> filterUsers(rqUserQuery rq)
        {
            rpUserQuery rp = new rpUserQuery();
            rp = await userObj.filterUsers(rq);
            return rp;
        }

        [HttpPost("registerFriendship")]
        public async Task<rpAddFriendship> registerFriendship(rqAddFriendship rq)
        {
            rpAddFriendship rp = new rpAddFriendship();
            rp = await userObj.registerFriendship(rq);
            if (rp.success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveNotifications", rp);
            }
            return rp;
        }

        #region groups

        [HttpPost("registerGroup")]
        public async Task<rpRegisterGroup> registerGroup(rqRegisterGroup rq)
        {
            rpRegisterGroup rp = new rpRegisterGroup();
            rp = await groupObj.registerGroup(rq);
            return rp;
        }

        [HttpPost("registerGroupMember")]
        public async Task<rpRegisterGroupMember> registerGroupMember(rqRegisterGroupMember rq)
        {
            rpRegisterGroupMember rp = new rpRegisterGroupMember();
            rp = await groupObj.registerGroupMember(rq);
            return rp;
        }

        [HttpPost("registerGroupMessages")]
        public async Task<rpRegisterGroupMessages> registerGroupMessages(rqRegisterGroupMessages rq)
        {
            rpRegisterGroupMessages rp = new rpRegisterGroupMessages();
            rp = await groupObj.registerGroupMessages(rq);
            if (rp.success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveGroupMessages", rp);
            }
            return rp;
        }

        [HttpPost("consultGroup")]
        public async Task<rpConsultGroup> consultGroup(rqConsultGroup rq)
        {
            rpConsultGroup rp = new rpConsultGroup();
            rp = await groupObj.consultGroup(rq);
            return rp;
        }

        [HttpPost("consultGroupMembers")]
        public async Task<rpConsultGroupMembers> consultGroupMembers(rqConsultGroupMembers rq)
        {
            rpConsultGroupMembers rp = new rpConsultGroupMembers();
            rp = await groupObj.consultGroupMembers(rq);
            return rp;
        }

        [HttpPost("consultGroupMessages")]
        public async Task<rpConsultGroupMessages> consultGroupMessages(rqConsultGroupMessages rq)
        {
            rpConsultGroupMessages rp = new rpConsultGroupMessages();
            rp = await groupObj.consultGroupMessages(rq);
            return rp;
        }

        #endregion

        [HttpPost("consultChats")]
        public async Task<rpConsultChats> consultChats(rqConsultChats rq)
        {
            rpConsultChats rp = new rpConsultChats();
            rp = await chatObj.consultChats(rq);
            return rp;
        }

        [HttpPost("LoginSession")]
        public async Task<rpLoginSession> LoginSession(rqLoginSession rq)
        {
            rpLoginSession rp = new rpLoginSession();
            rp = await sessionObj.LoginSession(rq);
            return rp;
        }

        [HttpPost("countGroupMessages")]
        public async Task<rpCountMessages> countGroupMessages(rqCountGroupMessages rq)
        {
            rpCountMessages rp = new rpCountMessages();
            rp = await groupObj.countGroupMessages(rq);
            return rp;
        }

        [HttpPost("countChats")]
        public async Task<rpCountChats> countChats(rqCountChats rq)
        {
            rpCountChats rp = new rpCountChats();
            rp = await chatObj.countChats(rq);
            return rp;
        }

        [HttpPost("mantNotifications")]
        public async Task<rpMantNotifications> mantNotifications(rqMantNotifications rq)
        {
            rpMantNotifications rp = new rpMantNotifications();
            rp = await notificationObj.mantNotifications(rq);
            return rp;
        }

        [HttpPost("conusltfriendshipsRequests")]
        public async Task<rpConsultfriendshipsRequests> conusltfriendshipsRequests(rqConsultfriendshipsRequests rq)
        {
            rpConsultfriendshipsRequests rp = new rpConsultfriendshipsRequests();
            rp = await userObj.conusltfriendshipsRequests(rq);
            return rp;
        }

        [HttpPost("SendSecurityCode")]
        public async Task<rpSendToken> SendSecurityCode(rqSendToken rq)
        {
            rpSendToken rp = new rpSendToken();
            rp = await tokenObj.SendSecurityCode(rq);
            return rp;
        }
    }
}
