using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Badminton_Competition_Management_System.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Example login logic – replace with your own
            if (Username == "admin" && Password == "1234")
            {
                // Redirect to another page if login is successful
                return RedirectToPage("Index"); // or any page you want
            }

            // If login fails, show error
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
