using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DarkMessages.models.Login;
using DarkMessages.Service.Objects;
using DarkMessages.models.SignUp;
using DarkMessages.models.Message;
using DarkMessages.models.Friends;

namespace DarkMessages.Service.Controllers
{
    [Route("api/darkmsgs")]
    [ApiController]
    public class DarkMessagesController : ControllerBase
    {
        UserObj userObj = new UserObj();
        MessageObj messageObj = new MessageObj();

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
            rp =await  messageObj.insertMessage(rq);
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
        

    }
}
