using InterfaceLayer.DTO;
using InterfaceLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Badminton_Competition_Management_System.Pages
{
    public class SeasonalTeamsModel : PageModel
    {
        private readonly SeasonalTeamService _manager;

        public SeasonalTeamsModel(SeasonalTeamService manager)
        {
            _manager = manager;
        }

        public List<SeasonsDTO> Seasons { get; set; }
        public List<TeamDTO> AllTeams { get; set; }
        public List<SeasonalTeamDTO> SeasonalTeams { get; set; }

        [BindProperty] public int SeasonId { get; set; }
        [BindProperty] public int TeamId { get; set; }
        [BindProperty] public int RemoveSeasonId { get; set; }
        [BindProperty] public int RemoveTeamId { get; set; }

        public async Task OnGetAsync()
        {
            Seasons = await _manager.GetAllSeasonsAsync();
            AllTeams = await _manager.GetAllTeamsAsync();
            SeasonalTeams = await _manager.GetAllSeasonalTeamsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeasonId > 0 && TeamId > 0)
            {
                await _manager.AddTeamToSeasonAsync(SeasonId, TeamId);
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostRemoveAsync()
        {
            await _manager.RemoveTeamFromSeasonAsync(RemoveSeasonId, RemoveTeamId);
            return RedirectToPage();
        }
    }
}
