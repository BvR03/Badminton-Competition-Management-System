using System.Data;
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
            try { 
            var connection = new MySqlConnection(_connectionString);
            query.Connection = connection;
            await connection.OpenAsync();
            return await query.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Database query failed.", ex);
            }
        }

        public static async Task<int> ExecuteAsync(MySqlCommand command)
        {
            try
            {
                var connection = new MySqlConnection(_connectionString);
                command.Connection = connection;
                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Database query failed.", ex);
            }
        }
    }
}