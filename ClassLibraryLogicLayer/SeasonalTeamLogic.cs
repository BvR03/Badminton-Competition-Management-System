using InterfaceLayer.DTO;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SeasonalTeamLogic
    {
        private readonly ISeasonalTeamData _data;

        public SeasonalTeamLogic(ISeasonalTeamData data)
        {
            _data = data;
        }

        public Task<List<DTOSeasons>> GetAllSeasonsAsync()
        {
            return _data.FetchAllSeasonsAsync();
        }

        public Task<List<DTOTeam>> GetAllTeamsAsync()
        {
            return _data.FetchAllTeamsAsync();
        }

        public Task<List<DTOSeasonalTeam>> GetAllSeasonalTeamsAsync()
        {
            return _data.FetchAllSeasonalTeamsAsync();
        }

        public Task AddTeamToSeasonAsync(int seasonId, int teamId)
        {
            return _data.AddTeamToSeasonAsync(seasonId, teamId);
        }

        // Optional helper for UI logic
        public async Task<List<DTOSeasons>> GetActiveSeasonsAsync()
        {
            var seasons = await _data.FetchAllSeasonsAsync();
            return seasons.Where(s => s.EndDate > DateTime.Now).ToList();
        }
        public Task RemoveTeamFromSeasonAsync(int seasonId, int teamId)
        {
            return _data.RemoveTeamFromSeasonAsync(seasonId, teamId);
        }

    }
}
