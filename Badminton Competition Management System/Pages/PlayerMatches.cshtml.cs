using LogicLayer;
using InterfaceLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Badminton_Competition_Management_System.Pages
{
    public class PlayerMatchesModel : PageModel
    {
        private readonly PlayerService _playerService;
        private readonly MatchService _matchService;

        public PlayerMatchesModel(PlayerService playerService, MatchService matchService)
        {
            _playerService = playerService;
            _matchService = matchService;
        }

        [BindProperty(SupportsGet = true)]
        public int FedNr { get; set; }

        public int PlayerId { get; set; }  
        public string PlayerName { get; set; } = "";
        public List<MatchDTO> Matches { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var player = await _playerService.FetchPlayerByFederationNumberAsync(FedNr);
            if (player == null)
                return NotFound();

            PlayerId = player.ID; 
            PlayerName = $"{player.FirstName} {player.LastName}";
            Matches = await _matchService.FetchMatchesByPlayerIdAsync(player.ID);

            return Page();
        }
    }
}
