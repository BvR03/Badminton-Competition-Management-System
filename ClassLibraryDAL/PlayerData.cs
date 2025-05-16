using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceNDTOLayer;
using MySqlConnector;

namespace DAL
{
    public class PlayerData
    {
        public static async Task<bool> InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber)
        {
            using var command = new MySqlCommand(@"
        INSERT INTO players (FirstName, LastName, Gender, FederationNumber)
        VALUES (@firstName, @lastName, @gender, @federationNumber)");

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender); 
            command.Parameters.AddWithValue("@federationNumber", federationNumber);

            int rowsAffected = await DatabaseManager.ExecuteAsync(command);
            return rowsAffected > 0;
        }
        public static async IAsyncEnumerable<DTOPlayers> FetchPlayersAsync()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM players"));
            while (await reader.ReadAsync())
            {
                yield return new DTOPlayers
                {
                    ID = reader.GetInt32("ID"),
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Gender = (bool)(reader["Gender"]),
                    FederationNumber = reader.GetInt32("FederationNumber")
                };
            }
        }
        public static async Task<bool> ExistingFederationNumber(int FederationNumber)
        {
            var cmd = new MySqlCommand("SELECT 1 FROM players WHERE FederationNumber = @FederationNumber LIMIT 1");
            cmd.Parameters.AddWithValue("@FederationNumber", FederationNumber);

            using MySqlDataReader reader = await DatabaseManager.Query(cmd);
            return await reader.ReadAsync(); 
        }

    }
}
