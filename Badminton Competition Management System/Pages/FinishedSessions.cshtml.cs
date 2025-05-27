using Badminton_Competition_Management_System.Pages.Shared;
using InterfaceLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Badminton_Competition_Management_System.Pages
{
    public class FinishedSessionsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FetchPlayDayService _LiveSessionData = new FetchPlayDayService();

        public FinishedSessionsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<SessionModel> Sessions { get; set; }

        public async Task OnGet()
        {
            Sessions = new List<SessionModel>();
            foreach (FinishedSessionsDTO session in await _LiveSessionData.GetFinishedSessionsAsync())
            {
                Sessions.Add(new SessionModel
                {
                    ID = session.ID,
                    Name = session.Name,
                    Description = session.Description,
                    StartTime = session.StartTime,
                    TimeFinished = session.TimeFinished

                });
            }
            //_LiveSessionData.ToString();
        }
    }
}
