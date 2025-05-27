using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO
{
    public class SeasonalTeamDTO
    {
        public int ID { get; set; }
        public int SeasonId { get; set; }
        public int TeamId { get; set; }
        public string SeasonName { get; set; }
        public string TeamName { get; set; }
    }
}
