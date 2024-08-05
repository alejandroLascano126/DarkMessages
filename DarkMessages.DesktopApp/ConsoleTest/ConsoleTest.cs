using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;



namespace ConsoleTest
{
    public class ConsoleTest
    {
        public static void Main(string[] args) 
        {
            string emailFrom = "darkmessages@outlook.com";
            string emailTo = "alejandrolascano126@gmail.com";
            string passwordFrom = "123*abc*456";
            string server = "smtp-mail.outlook.com";


            try
            {
                // Specify the SMTP server and port.
                SmtpClient client = new SmtpClient(server, 587)
                {
                    // Specify the sender's email address and password.
                    Credentials = new NetworkCredential(emailFrom, passwordFrom),
                    EnableSsl = true
                };

                // Create the email message.
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(emailFrom),
                    Subject = "Test Email",
                    Body = "This is a test email sent from C# code using SMTP.",
                    IsBodyHtml = true
                };

                // Add the recipient's email address.
                mailMessage.To.Add(emailTo);

                // Send the email.
                client.Send(mailMessage);

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return;

            using var email =  new MimeMessage();
            email.From.Add(new MailboxAddress("Dark Messages", "darkmessages@outlook.com"));
            email.To.Add(new MailboxAddress("Alejandro Lascano", "alejandrolascano126@gmail.com"));

            email.Subject = "Security code to login";

            var builder = new BodyBuilder() 
            {
                HtmlBody = @"<h1>SECURITY CODE 777777</h1>"
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential(emailFrom, passwordFrom);
            //smtp.Send(email);





            return;

            try
            {
                var smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(emailFrom, passwordFrom),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailFrom),
                    Subject = "Security code to login",
                    Body = $"<h1>SECURITY CODE {777777}</h1>",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(emailTo);
                
                smtpClient.SendMailAsync(mailMessage);
                
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"Error: {smtpEx}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }

            return;



            Console.WriteLine("Hola mundo");
            Console.ReadLine();
        }
    }
}
