using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using InterfaceLayer.DTO;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class SeasonalTeamData : ISeasonalTeamData
    {
        public async Task<List<DTOSeasons>> FetchAllSeasonsAsync()
        {
            var list = new List<DTOSeasons>();
            var cmd = new MySqlCommand("SELECT ID, Name, StartDate, EndDate FROM seasons ORDER BY EndDate DESC");

            using var reader = await DatabaseManager.Query(cmd);
            while (await reader.ReadAsync())
            {
                list.Add(new DTOSeasons
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.GetDateTime("EndDate")
                });
            }

            return list;
        }

        public async Task<List<DTOTeam>> FetchAllTeamsAsync()
        {
            var list = new List<DTOTeam>();
            var cmd = new MySqlCommand("SELECT ID, Name FROM teams");

            using var reader = await DatabaseManager.Query(cmd);
            while (await reader.ReadAsync())
            {
                list.Add(new DTOTeam
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name")
                });
            }

            return list;
        }

        public async Task<List<DTOSeasonalTeam>> FetchAllSeasonalTeamsAsync()
        {
            var list = new List<DTOSeasonalTeam>();
            var cmd = new MySqlCommand(@"
                SELECT st.ID, st.SeasonId, st.TeamId, s.Name AS SeasonName, t.Name AS TeamName
                FROM seasonalteams st
                INNER JOIN seasons s ON s.ID = st.SeasonId
                INNER JOIN teams t ON t.ID = st.TeamId");

            using var reader = await DatabaseManager.Query(cmd);
            while (await reader.ReadAsync())
            {
                list.Add(new DTOSeasonalTeam
                {
                    ID = reader.GetInt32("ID"),
                    SeasonId = reader.GetInt32("SeasonId"),
                    TeamId = reader.GetInt32("TeamId"),
                    SeasonName = reader.GetString("SeasonName"),
                    TeamName = reader.GetString("TeamName")
                });
            }

            return list;
        }

        public async Task AddTeamToSeasonAsync(int seasonId, int teamId)
        {
            var cmd = new MySqlCommand("INSERT INTO seasonalteams (SeasonId, TeamId) VALUES (@seasonId, @teamId)");
            cmd.Parameters.AddWithValue("@seasonId", seasonId);
            cmd.Parameters.AddWithValue("@teamId", teamId);
            await DatabaseManager.ExecuteAsync(cmd);
        }
        public async Task RemoveTeamFromSeasonAsync(int seasonId, int teamId)
        {
            var cmd = new MySqlCommand("DELETE FROM seasonalteams WHERE SeasonId = @seasonId AND TeamId = @teamId");
            cmd.Parameters.AddWithValue("@seasonId", seasonId);
            cmd.Parameters.AddWithValue("@teamId", teamId);
            await DatabaseManager.ExecuteAsync(cmd);
        }
    }
}
