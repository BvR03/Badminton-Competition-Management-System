using InterfaceLayer.DTO;
using InterfaceLayer.DALInterfaces;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class TeamData : ITeamData
    {
        public async Task AddTeamAsync(string name)
        {
            using var command = new MySqlCommand("INSERT INTO teams (Name) VALUES (@name)");
            command.Parameters.AddWithValue("@name", name);

            await DatabaseManager.ExecuteAsync(command);
        }

        public async Task<List<DTOTeam>> GetAllTeamsAsync()
        {
            var teams = new List<DTOTeam>();
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT ID, Name FROM teams ORDER BY Name"));

            while (await reader.ReadAsync())
            {
                teams.Add(new DTOTeam
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name")
                });
            }

            return teams;
        }
    }
}

