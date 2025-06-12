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
        public int? PlayerID { get; set; }
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public bool Gender { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Message { get; set; }
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
                    FederationNumber = myPlayers.FederationNumber,
                    Email = myPlayers.Email
                });
            }
        }

        public async Task OnGetAsync()
        {
            await LoadPlayersAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            string Status = await CreationCheck.CanPlayerBeCreated(FirstName, LastName, Gender, FederationNumber);

            switch (Status)
            {
                case "CanCreate":
                    await _playerLogic.CreatePlayer(FirstName, LastName, Gender, FederationNumber, Email);
                    return RedirectToPage();
                case "ExistingFederationNumber":
                    ModelState.AddModelError(string.Empty, "A player with this Federation Number already exists.");
                    break;
                case "NoFirstName":
                case "NoLastName":
                case "NoFederationNumber":
                    ModelState.AddModelError(string.Empty, "All fields are required.");
                    break;
                default:
                    ModelState.AddModelError(string.Empty, "Unknown error.");
                    break;
            }

            await LoadPlayersAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            //if (FederationNumber != null)
            //{
                await _playerLogic.UpdatePlayerByFederationNumber(FirstName, LastName, Gender, FederationNumber, Email);
                return RedirectToPage();
            //}

            //ModelState.AddModelError(string.Empty, "Invalid player edit attempt.");
            //await LoadPlayersAsync();
            //return Page();
        }
        public async Task<IActionResult> OnPostSendEmailAsync()
        {
            var emailService = new EmailService();
            emailService.SetUpEmail(Subject, Email, Message);
            return RedirectToPage();
        }
    }
}

