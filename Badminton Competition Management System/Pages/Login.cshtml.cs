using LogicLayer;
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

        // Mark the method as 'async'
        public async Task<IActionResult> OnPostAsync()
        {
            // Await the VerifyLogin method to get the result
            bool isLoginValid = await LoginManager.VerifyLogin(Username, Password);

            if (isLoginValid)
            {
                // Redirect to another page if login is successful
                return RedirectToPage("Index"); // Or any page you want to redirect to
            }

            // If login fails, show error
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page(); // Return to the current page with the error message in ModelState
        }
    }
}
