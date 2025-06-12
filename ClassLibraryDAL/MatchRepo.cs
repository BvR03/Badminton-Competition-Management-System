using InterfaceLayer.DALInterfaces;
using InterfaceLayer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MatchRepo : IMatchRepo
    {
        public async IAsyncEnumerable<MatchDTO> FetchMatchesAsync()
        {
            using MySqlDataReader reader = await DatabaseManager.Query(
                new MySqlCommand("SELECT * FROM matches"));

            while (await reader.ReadAsync())
            {
                yield return new MatchDTO
                {
                    ID = reader.GetInt32("ID"),
                    PlayerID = reader.GetInt32("PlayerID"),
                    PlayerIDP2 = reader["PlayerIDP2"] == DBNull.Value ? null : reader.GetInt32("PlayerIDP2"),
                    OpponentName = reader.GetString("OpponentName"),
                    OpponentNameP2 = reader["OpponentNameP2"] == DBNull.Value ? null : reader.GetString("OpponentNameP2"),
                    CourtNumber = reader.GetInt32("CourtNumber"),
                    ScoreHomeSet1 = reader.GetInt32("ScoreHomeSet1"),
                    ScoreAwaySet1 = reader.GetInt32("ScoreAwaySet1"),
                    ScoreHomeSet2 = reader.GetInt32("ScoreHomeSet2"),
                    ScoreAwaySet2 = reader.GetInt32("ScoreAwaySet2"),
                    ScoreHomeSet3 = reader["ScoreHomeSet3"] == DBNull.Value ? null : reader.GetInt32("ScoreHomeSet3"),
                    ScoreAwaySet3 = reader["ScoreAwaySet3"] == DBNull.Value ? null : reader.GetInt32("ScoreAwaySet3"),
                    TimeFinished = reader["TimeFinished"] == DBNull.Value ? null : reader.GetDateTime("TimeFinished")
                };
            }
        }
    }

}
