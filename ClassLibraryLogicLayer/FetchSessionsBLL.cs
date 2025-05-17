using DAL;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace LogicLayer
{
    public class FetchSessionsBLL
    {
        public async Task<List<DTOLiveSessions>> GetLiveSessionsAsync()
        {
            var result = new List<DTOLiveSessions>();
            await foreach (DTOLiveSessions session in FetchSessionData.FetchSessions())
            {
                result.Add(session);
            }
            return result;
        }
        public async Task<List<DTOFinishedSessions>> GetFinishedSessionsAsync()
        {
            var result = new List<DTOFinishedSessions>();
            await foreach (DTOFinishedSessions session in FetchSessionData.FetchFinishedSessions())
            {
                result.Add(session);
            }
            return result;
        }
    }
}
