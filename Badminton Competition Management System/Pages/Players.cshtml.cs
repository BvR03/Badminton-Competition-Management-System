using Badminton_Competition_Management_System.Pages.Shared;
using InterfaceLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
namespace Badminton_Competition_Management_System.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly PlayerService _playerLogic;

        public PlayersModel(PlayerService playerLogic)
        {
            _playerLogic = playerLogic;
        }
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public bool Gender { get; set; }

        [BindProperty]
        public int FederationNumber { get; set; }

        public List<PlayerModel> Players { get; set; }

        private async Task LoadPlayersAsync()
        {
            Players = new List<PlayerModel>();
            foreach (PlayersDTO myPlayers in await _playerLogic.FetchPlayersAsync())
            {
                Players.Add(new PlayerModel
                {
                    ID = myPlayers.ID,
                    FirstName = myPlayers.FirstName,
                    LastName = myPlayers.LastName,
                    Gender = myPlayers.Gender,
                    FederationNumber = myPlayers.FederationNumber
                });
            }
        }

        public async Task OnGetAsync()
        {
            await LoadPlayersAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string Status = await CreationCheck.CanPlayerBeCreated(FirstName, LastName, Gender, FederationNumber);

            switch (Status)
            {
                case "ExistingFederationNumber":
                    ModelState.AddModelError(string.Empty, "A player with this Federation Number already exists.");
                    break;
                case "NoFirstName":
                    ModelState.AddModelError(string.Empty, "First name is required.");
                    break;
                case "NoLastName":
                    ModelState.AddModelError(string.Empty, "Last name is required.");
                    break;
                case "NoFederationNumber":
                    ModelState.AddModelError(string.Empty, "Federation Number is required.");
                    break;
                case "CanCreate":
                    await _playerLogic.CreatePlayer(FirstName, LastName, Gender, FederationNumber);
                    return RedirectToPage();
                default:
                    ModelState.AddModelError(string.Empty, "An unknown error occurred.");
                    break;
            }
            ViewData["ShowModal"] = true;
            await LoadPlayersAsync();
            return Page();
        }
    }
}

