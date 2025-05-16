using DAL;
using InterfaceNDTOLayer;
namespace LogicLayer
{
    public class PlayerLogic
    {
        public async Task CreatePlayer(string firstName, string lastName, bool gender, int federationNumber)
        {
            await PlayerData.InsertPlayerAsync(firstName, lastName, gender, federationNumber);
            // No return value — assumes validation has already passed
        }

        public async Task<List<DTOPlayers>> FetchPlayersAsync()
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
