using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Badminton_Competition_Management_System.Pages.Shared
{
    public class SessionModel : PageModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? TimeFinished { get; set; }

        public void OnGet()
        {
            Name = "Sample Title";
            Description = "This is a description.";
            StartTime = DateTime.Now;
        }
    }
}
