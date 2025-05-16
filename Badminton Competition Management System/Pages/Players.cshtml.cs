using Badminton_Competition_Management_System.Pages.Shared;
using InterfaceNDTOLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Badminton_Competition_Management_System.Pages
{
    public class PlayersModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public bool Gender { get; set; }

        [BindProperty]
        public int FederationNumber { get; set; }

        public List<PlayerModel> Players { get; set; }

        public async Task OnGetAsync()
        {
            Players = new List<PlayerModel>();
            foreach (DTOPlayers myPlayers in await PlayerLogic.FetchPlayersAsync())
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
                    bool success = await PlayerLogic.CreatePlayer(FirstName, LastName, Gender, FederationNumber);
                    if (success)
                    {
                        return RedirectToPage(); // Redirect to the same page or success page
                    }
                    else
                    {
                        return RedirectToPage("/Login"); // Or handle failure differently
                    }

                default:
                    ModelState.AddModelError(string.Empty, "An unknown error occurred.");
                    break;
            }
            return Page();
        }
    }
}
