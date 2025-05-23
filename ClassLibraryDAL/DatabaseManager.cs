﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace DAL
{
    class DatabaseManager
    {
        //private readonly string _connectionString;

        public static async Task<MySqlDataReader> Query(MySqlCommand Query) {
            var connectionString = "Server = localhost; Database = db_ipf; Uid = root; Pwd =; ";
            var connection = new MySqlConnection(connectionString);
            Query.Connection = connection;
            await connection.OpenAsync();
            MySqlDataReader data = await Query.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            return data;
                
            
        }
        public static async Task<int> ExecuteAsync(MySqlCommand command)
        {
            var connectionString = "Server=localhost; Database=db_ipf; Uid=root; Pwd=;";
            using var connection = new MySqlConnection(connectionString);
            command.Connection = connection;
            await connection.OpenAsync();
            return await command.ExecuteNonQueryAsync(); // returns number of affected rows
        }

    }
}
