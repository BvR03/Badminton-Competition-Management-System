using System.Net.Mail;
using System.Net;

namespace BCM.InfrastructureLayer
{
    public class EmailHandler
    {
        public static void SendMessage(string Sender, string EmailPassword, string subject, string toEmail, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(Sender, EmailPassword),
                EnableSsl = true
            };

            var mail = new MailMessage("fontystestmails@gmail.com", toEmail)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = false // Change to true if you're using HTML formatting
            };

            client.Send(mail);
        }
    }
}
