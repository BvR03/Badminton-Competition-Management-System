using Badminton_Competition_Management_System.Pages.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using InterfaceLayer;
using System.Threading.Tasks;
using DAL;
using MySqlX.XDevAPI.Common;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FetchPlayDayService _LiveSessionData = new FetchPlayDayService();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<SessionModel> Sessions { get; set; }

    public async Task OnGet()
    {
        Sessions = new List<SessionModel>();
        foreach (LiveSessionsDTO session in await _LiveSessionData.GetLiveSessionsAsync())
        {
            Sessions.Add( new SessionModel 
            {
                ID = session.ID,
                Name = session.Name,
                Description = session.Description,
                StartTime = session.StartTime,
            
            } );
        }
        //_LiveSessionData.ToString();
    }
}
