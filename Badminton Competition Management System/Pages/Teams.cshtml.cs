using InterfaceLayer.DTO;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Badminton_Competition_Management_System.Pages
{
    public class TeamsModel : PageModel
    {
        private readonly TeamService _teamManager;

        public TeamsModel(TeamService teamManager)
        {
            _teamManager = teamManager;
        }

        public List<TeamDTO> Teams { get; set; } = new();

        [BindProperty]
        public string TeamName { get; set; }

        public async Task OnGetAsync()
        {
            Teams = await _teamManager.GetTeamsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(TeamName))
            {
                await _teamManager.AddTeamAsync(TeamName);
            }

            return RedirectToPage();
        }
    }
}
