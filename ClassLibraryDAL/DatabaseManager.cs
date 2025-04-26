using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    class DatabaseManager
    {
        private readonly string _connectionString = "Server=localhost;Database=your_database_name;Uid=root;Pwd=;";

        public async Task<bool> ConnectionTest() {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }
    }
}
