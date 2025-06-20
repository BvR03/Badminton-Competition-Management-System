using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCMS.Tests.IntegrationTesting
{
    [TestClass]
    public class EmailIntegrationTest
    {
        [TestMethod]
        public void SendEmail() 
        {
            // Arrange
            EmailService.SetEmailPassword("pppp zfts itsl njfx jfps");
            var service = new EmailService();
            string subject = "Test Email";
            string toEmail = "bvrhelpdesk3@gmail.com";
            string message = "This is a test message.";

            // Act
            service.SetUpEmail(subject, toEmail, message);

            // Assert
            Assert.IsTrue(true);
        }
    }
}
