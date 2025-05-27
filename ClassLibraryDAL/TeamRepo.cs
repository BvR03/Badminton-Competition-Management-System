using InterfaceLayer.DTO;
using InterfaceLayer.DALInterfaces;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class TeamRepo : ITeamRepo
    {
        public async Task AddTeamAsync(string name)
        {
            using var command = new MySqlCommand("INSERT INTO teams (Name) VALUES (@name)");
            command.Parameters.AddWithValue("@name", name);

            await DatabaseManager.ExecuteAsync(command);
        }

        public async Task<List<TeamDTO>> GetAllTeamsAsync()
        {
            var teams = new List<TeamDTO>();
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT ID, Name FROM teams ORDER BY Name"));

            while (await reader.ReadAsync())
            {
                teams.Add(new TeamDTO
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name")
                });
            }

            return teams;
        }
    }
}

