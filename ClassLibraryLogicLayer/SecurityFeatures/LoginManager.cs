using DAL;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public static class LoginManager
    {
        private static readonly IPasswordGrabber _passwordGrabber = new LogInDAL();
        public static async Task<bool> VerifyLogin(string username, string password)
        {
            string hashedPassword = Hasher.Hash(password);
            string? storedPasswordHash = await _passwordGrabber.getPasswordHashByUsername(username);
            if (storedPasswordHash == null)
            {
                return false;
            }
            return hashedPassword == storedPasswordHash;
        }
    }
}
