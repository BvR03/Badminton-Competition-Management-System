using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceNDTOLayer;
using MySqlConnector;

namespace DAL
{
    public class FetchSessionData
    {
        public static async IAsyncEnumerable<DTOLiveSessions> FetchSessions()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(new MySqlCommand("SELECT * FROM session WHERE TimeFinished != NULL"));
            while (await reader.ReadAsync())
            {
                yield return new DTOLiveSessions 
                {
                    ID = reader.GetInt32("ID"),
                    Name = (string)reader["customerID"],
                    Description = (string)reader["workerID"],
                    StartTime = Convert.ToDateTime(reader["lastResponse"])
                };
            }
        }
    }
}
