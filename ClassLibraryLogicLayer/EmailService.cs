using BCM.InfrastructureLayer;

namespace LogicLayer
{
    public class EmailService
    {
        private static string _emailPassword;

        public static void SetEmailPassword(string password)
        {
            _emailPassword = password;
        }

        public void SetUpEmail(string subject, string toEmail, string message)
        {
            string sender = "fontystestmails@gmail.com";
            EmailHandler.SendMessage(sender, _emailPassword, subject, toEmail, message);
        }
    }

}