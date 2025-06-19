using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace DAL
{
    public static class DatabaseManager
    {
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<MySqlDataReader> Query(MySqlCommand query)
        {
            var connection = new MySqlConnection(_connectionString);
            query.Connection = connection;
            await connection.OpenAsync();
            return await query.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        public static async Task<int> ExecuteAsync(MySqlCommand command)
        {
            var connection = new MySqlConnection(_connectionString);
            command.Connection = connection;
            await connection.OpenAsync();
            return await command.ExecuteNonQueryAsync();
        }
    }
}