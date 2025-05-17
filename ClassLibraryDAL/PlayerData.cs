using InterfaceLayer;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayerData : IPlayerData
    {
        public async Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber)
        {
            using var command = new MySqlCommand(@"
                INSERT INTO players (FirstName, LastName, Gender, FederationNumber)
                VALUES (@firstName, @lastName, @gender, @federationNumber)");

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@federationNumber", federationNumber);

            await DatabaseManager.ExecuteAsync(command);
        }

        public async IAsyncEnumerable<DTOPlayers> FetchPlayersAsync()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM players"));
            while (await reader.ReadAsync())
            {
                yield return new DTOPlayers
                {
                    ID = reader.GetInt32("ID"),
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Gender = (bool)reader["Gender"],
                    FederationNumber = reader.GetInt32("FederationNumber")
                };
            }
        }

        public static async Task<bool> ExistingFederationNumber(int federationNumber)
        {
            var cmd = new MySqlCommand("SELECT 1 FROM players WHERE FederationNumber = @FederationNumber LIMIT 1");
            cmd.Parameters.AddWithValue("@FederationNumber", federationNumber);

            using MySqlDataReader reader = await DatabaseManager.Query(cmd);
            return await reader.ReadAsync();
        }
    }
}

