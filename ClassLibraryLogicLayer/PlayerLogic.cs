using DAL;
using InterfaceNDTOLayer;
namespace LogicLayer
{
    public static class PlayerLogic
    {
        public static async Task<bool> CreatePlayer(string FirstName, string LastName, bool Gender, int FederationNumber)
        {
            bool Succes = await PlayerData.InsertPlayerAsync(FirstName, LastName, Gender, FederationNumber);
            return Succes;
        }

        public static async Task<List<DTOPlayers>> GetLiveSessionsAsync()
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
