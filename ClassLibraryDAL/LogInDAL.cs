using InterfaceLayer;
using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace DAL
{
    public class LogInDAL : IPasswordGrabber
    {
        public async Task<string?> getPasswordHashByUsername(string username)
        {
            var cmd = new MySqlCommand("SELECT password FROM adminusers WHERE Username = @username");
            cmd.Parameters.AddWithValue("@username", username);

            using MySqlDataReader reader = await DatabaseManager.Query(cmd);
            if (await reader.ReadAsync())
            {
                return reader.GetString("password");
            }

            return null;
        }
    }
}
