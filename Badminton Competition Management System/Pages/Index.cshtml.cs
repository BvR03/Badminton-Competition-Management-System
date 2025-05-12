using Badminton_Competition_Management_System.Pages.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using InterfaceNDTOLayer;
using System.Threading.Tasks;
using DAL;
using MySqlX.XDevAPI.Common;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FetchSessionsBLL _LiveSessionData = new FetchSessionsBLL();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<SessionModel> Sessions { get; set; }

    public async Task OnGet()
    {
        Sessions = new List<SessionModel>();
        foreach (DTOLiveSessions session in await _LiveSessionData.GetLiveSessionsAsync())
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
