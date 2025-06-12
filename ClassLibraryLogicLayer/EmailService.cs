using System;
using System.Collections.Generic;
using System.Linq;
using BCM.InfrastructureLayer;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class EmailService
    {
        public void SetUpEmail(string subject, string toEmail, string message)
        {
            string Sender = "fontystestmails@gmail.com";
            string EmailPassword = EmailPasswordService.ReturnEmailPassword();
            EmailHandler.SendMessage(Sender, EmailPassword, subject, toEmail, message);
        }
    }
}
