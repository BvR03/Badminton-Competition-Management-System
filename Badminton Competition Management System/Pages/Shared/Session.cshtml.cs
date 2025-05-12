using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Badminton_Competition_Management_System.Pages.Shared
{
    public class SessionModel : PageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public void OnGet()
        {
            Title = "Sample Title";
            Description = "This is a description.";
            Time = "10:00 AM";
        }
    }
}
