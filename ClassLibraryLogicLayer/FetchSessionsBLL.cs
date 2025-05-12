using DAL;
using InterfaceNDTOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace LogicLayer
{
    class FetchSessionsBLL
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
    }
}
