using InterfaceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PlayerLogic
    {
        private readonly IPlayerData _playerData;

        public PlayerLogic(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public async Task CreatePlayer(string firstName, string lastName, bool gender, int federationNumber)
        {
            await _playerData.InsertPlayerAsync(firstName, lastName, gender, federationNumber);
        }

        public async Task<List<DTOPlayers>> FetchPlayersAsync()
        {
            var result = new List<DTOPlayers>();
            await foreach (DTOPlayers myPlayers in _playerData.FetchPlayersAsync())
            {
                result.Add(myPlayers);
            }
            return result;
        }
    }
}

