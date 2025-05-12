using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace LogicLayer
{
    public static class Hasher
    {
        public static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                    hashBuilder.Append(b.ToString("x2"));

                string hash = hashBuilder.ToString();
                return hash;
            }
        }
    }
}
