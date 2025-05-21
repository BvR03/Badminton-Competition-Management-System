using InterfaceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ISeasonalTeamData
    {
        Task<List<DTOSeasons>> FetchAllSeasonsAsync();
        Task<List<DTOTeam>> FetchAllTeamsAsync();
        Task<List<DTOSeasonalTeam>> FetchAllSeasonalTeamsAsync();
        Task AddTeamToSeasonAsync(int seasonId, int teamId);
        Task RemoveTeamFromSeasonAsync(int seasonId, int teamId);
    }
}
