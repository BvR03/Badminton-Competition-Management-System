using DAL;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace LogicLayer
{
    public class FetchPlayDayService
    {
        public async Task<List<LiveSessionsDTO>> GetLiveSessionsAsync()
        {
            var result = new List<LiveSessionsDTO>();
            await foreach (LiveSessionsDTO session in FetchPlayDayRepo.FetchSessions())
            {
                result.Add(session);
            }
            return result;
        }
        public async Task<List<FinishedSessionsDTO>> GetFinishedSessionsAsync()
        {
            var result = new List<FinishedSessionsDTO>();
            await foreach (FinishedSessionsDTO session in FetchPlayDayRepo.FetchFinishedSessions())
            {
                result.Add(session);
            }
            return result;
        }
    }
}
