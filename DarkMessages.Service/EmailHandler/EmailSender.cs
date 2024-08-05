using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.DesktopApp
{
    public class EmailSender : IEmailSender
    {
        public Task<bool> SendEmailAsync(string emailTo, string subject, string message, int? securityCode)
        {
            string emailFrom = "darkmessages@outlook.com";
            string passwordFrom = "123*abc*456";
            string server = "smtp-mail.outlook.com";
            try
            {
                SmtpClient client = new SmtpClient(server, 587)
                {
                    Credentials = new NetworkCredential(emailFrom, passwordFrom),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(emailFrom),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                if (securityCode != null)
                {
                    mailMessage.Subject = "Security code to login";
                    mailMessage.Body = $"<h1>SECURITY CODE: {securityCode}</h1>";
                }

                mailMessage.To.Add(emailTo);

                client.Send(mailMessage);



                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
