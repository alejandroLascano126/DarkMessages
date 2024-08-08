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

namespace DarkMessages.Service.Controllers
{
    [Route("api/darkmsgs")]
    [ApiController]
    public class DarkMessagesController : ControllerBase
    {
        UserObj userObj = new UserObj();
        MessageObj messageObj = new MessageObj();
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
            return rp;
        }



    }
}
