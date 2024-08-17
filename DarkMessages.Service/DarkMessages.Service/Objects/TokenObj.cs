using DarkMessages.DesktopApp;
using DarkMessages.models.Login;
using DarkMessages.models.Token;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DarkMessages.Service.Objects
{
    public class TokenObj
    {
        EmailSender emailSender;
        UserObj userObj;

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = GlobalVariables.DataSource,
            InitialCatalog = GlobalVariables.InitialCatalog,
            UserID = GlobalVariables.UserID,
            Password = GlobalVariables.Password,
            ConnectTimeout = GlobalVariables.ConnectTimeout,
            Encrypt = GlobalVariables.Encrypt,
            TrustServerCertificate = GlobalVariables.TrustServerCertificate,
        };

        string connectionString = "";

        public TokenObj()
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
            userObj = new UserObj();
        }

        public async Task<rpSendToken> SendSecurityCode(rqSendToken rq)
        {
            rpSendToken rp = new rpSendToken();
            rp.success = false;
            rp.message = "";
            try
            {
                int securityCode = 0;
                int sc = 0;
                Random random = new Random();
                sc = random.Next(100000, 999999);
                bool resp = await emailSender.SendEmailAsync(rq.email, "", "", sc);
                if (resp)
                {
                    rqValidateSecurityCode rqReg = new rqValidateSecurityCode();
                    rqReg.idUser = rq.userId;
                    rqReg.securityCode = sc;
                    bool rersp = await userObj.RegisterSecurityCodeDB(rqReg);
                    if (rersp)
                    {
                        rp.message = (resp) ? "An security code has been sent to alejan**********@gmail.com" : "Error sending the security code";
                        rp.success = true;
                    }
                }
            }
            catch
            {
                rp.success = false;
                rp.message = "";
                return rp;
            }
            return rp;
        }





    }
}
