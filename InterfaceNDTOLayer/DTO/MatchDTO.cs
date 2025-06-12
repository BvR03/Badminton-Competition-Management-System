using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO
{
    public class MatchDTO
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int? PlayerIDP2 { get; set; }
        public string? Player1Name { get; set; }
        public string? PartnerName { get; set; }


        public string OpponentName { get; set; } = string.Empty;
        public string? OpponentNameP2 { get; set; }

        public int CourtNumber { get; set; }

        public int ScoreHomeSet1 { get; set; }
        public int ScoreAwaySet1 { get; set; }
        public int ScoreHomeSet2 { get; set; }
        public int ScoreAwaySet2 { get; set; }

        public int? ScoreHomeSet3 { get; set; }
        public int? ScoreAwaySet3 { get; set; }

        public DateTime? TimeFinished { get; set; }
    }

}
