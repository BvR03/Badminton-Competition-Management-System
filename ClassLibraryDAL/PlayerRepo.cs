using InterfaceLayer;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayerRepo : IPlayerRepo
    {
        public async Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email)
        {
            using var command = new MySqlCommand(@"
                INSERT INTO players (FirstName, LastName, Gender, FederationNumber, Email)
                VALUES (@firstName, @lastName, @gender, @federationNumber, @email)");

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@federationNumber", federationNumber);
            command.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : email);

            await DatabaseManager.ExecuteAsync(command);
        }
        public async Task UpdatePlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email)
        {
            using var command = new MySqlCommand(@"
                UPDATE players  SET FirstName = @firstName, LastName = @lastName,Gender = @gender, Email = @email WHERE FederationNumber = @federationNumber");
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@federationNumber", federationNumber);
            command.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : email);

            await DatabaseManager.ExecuteAsync(command);
        }

        public async IAsyncEnumerable<PlayersDTO> FetchPlayersAsync()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM players"));
            while (await reader.ReadAsync())
            {
                yield return new PlayersDTO
                {
                    ID = reader.GetInt32("ID"),
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Gender = (bool)reader["Gender"],
                    FederationNumber = reader.GetInt32("FederationNumber"),
                    Email = reader["Email"] == DBNull.Value ? null : reader.GetString("Email")
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
        public async Task<PlayersDTO?> GetByFederationNumberAsync(int federationNumber)
        {
            await foreach (var player in FetchPlayersAsync())
            {
                if (player.FederationNumber == federationNumber)
                {
                    return player;
                }
            }

            return null;
        }
        public async Task<PlayersDTO?> FetchPlayerByIdAsync(int id)
        {
            await foreach (var player in FetchPlayersAsync())
            {
                if (player.ID == id)
                {
                    return player;
                }
            }
            return null;
        }
    }
}

