using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;
using MySqlConnector;

namespace DAL
{
    public class FetchSessionData
    {
        public static async IAsyncEnumerable<DTOLiveSessions> FetchSessions()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM session WHERE TimeFinished IS NULL"));
            while (await reader.ReadAsync())
            {
                yield return new DTOLiveSessions 
                {
                    ID = reader.GetInt32("ID"),
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    StartTime = Convert.ToDateTime(reader["StartTime"])
                };
            }
        }
        public static async IAsyncEnumerable<DTOFinishedSessions> FetchFinishedSessions()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM session WHERE TimeFinished IS NOT NULL"));
            while (await reader.ReadAsync())
            {
                yield return new DTOFinishedSessions
                {
                    ID = reader.GetInt32("ID"),
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    StartTime = Convert.ToDateTime(reader["StartTime"]),
                    TimeFinished = Convert.ToDateTime(reader["TimeFinished"])
                };
            }
        }
    }
}
