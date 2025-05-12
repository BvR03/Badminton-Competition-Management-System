using Badminton_Competition_Management_System.Pages.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<SessionModel> Sessions { get; set; }

    public void OnGet()
    {
        // Sample data - you could replace this with real data from a database or API
        Sessions = new List<SessionModel>
        {
            new SessionModel { Title = "BC Echt Competition", Description = "Teams 7, Courts 10", Time = "9:00AM" },
            new SessionModel { Title = "RBC Competition", Description = "Teams 3, Courts 2", Time = "10:00AM" },
            new SessionModel { Title = "Eredivisie", Description = "Teams 4, Courts 8", Time = "07:00 PM" }
        };
    }
}
