using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            bool Succes = await PlayerLogic.CreatePlayer(FirstName, LastName, Gender, FederationNumber);
            if (Succes == true)
            {
                return RedirectToPage();
            }
            else {
                return RedirectToPage("/Login");
            }
        }
    }
}