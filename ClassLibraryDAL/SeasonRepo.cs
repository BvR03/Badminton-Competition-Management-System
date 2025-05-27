using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class SeasonRepo : ISeasonRepo
    {
        public async Task<List<SeasonsDTO>> FetchSeasonsAsync()
        {
            var seasons = new List<SeasonsDTO>();
            var cmd = new MySqlCommand("SELECT * FROM seasons");

            using var reader = await DatabaseManager.Query(cmd);
            while (await reader.ReadAsync())
            {
                seasons.Add(new SeasonsDTO
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.GetDateTime("EndDate")
                });
            }

            return seasons;
        }

        public async Task InsertSeasonAsync(string name, DateTime start, DateTime end)
        {
            var cmd = new MySqlCommand(@"
        INSERT INTO seasons (Name, StartDate, EndDate)
        VALUES (@name, @start, @end)");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);

            await DatabaseManager.ExecuteAsync(cmd);
        }

    }
}
