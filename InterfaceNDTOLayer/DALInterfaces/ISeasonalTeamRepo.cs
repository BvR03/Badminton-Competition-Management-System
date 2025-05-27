using InterfaceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ISeasonalTeamRepo
    {
        Task<List<SeasonsDTO>> FetchAllSeasonsAsync();
        Task<List<TeamDTO>> FetchAllTeamsAsync();
        Task<List<SeasonalTeamDTO>> FetchAllSeasonalTeamsAsync();
        Task AddTeamToSeasonAsync(int seasonId, int teamId);
        Task RemoveTeamFromSeasonAsync(int seasonId, int teamId);
    }
}
