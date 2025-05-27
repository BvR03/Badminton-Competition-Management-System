using InterfaceLayer.DTO;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SeasonalTeamService
    {
        private readonly ISeasonalTeamRepo _data;

        public SeasonalTeamService(ISeasonalTeamRepo data)
        {
            _data = data;
        }

        public Task<List<SeasonsDTO>> GetAllSeasonsAsync()
        {
            return _data.FetchAllSeasonsAsync();
        }

        public Task<List<TeamDTO>> GetAllTeamsAsync()
        {
            return _data.FetchAllTeamsAsync();
        }

        public Task<List<SeasonalTeamDTO>> GetAllSeasonalTeamsAsync()
        {
            return _data.FetchAllSeasonalTeamsAsync();
        }

        public Task AddTeamToSeasonAsync(int seasonId, int teamId)
        {
            return _data.AddTeamToSeasonAsync(seasonId, teamId);
        }

        // Optional helper for UI logic
        public async Task<List<SeasonsDTO>> GetActiveSeasonsAsync()
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
