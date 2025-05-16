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

        public static async Task<List<DTOPlayers>> FetchPlayersAsync()
        {
            var result = new List<DTOPlayers>();
            await foreach (DTOPlayers myPlayers in PlayerData.FetchPlayersAsync())
            {
                result.Add(myPlayers);
            }
            return result;
        }
    }
}
