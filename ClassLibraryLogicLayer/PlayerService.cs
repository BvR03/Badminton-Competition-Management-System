using InterfaceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PlayerService
    {
        private readonly IPlayerRepo _playerData;

        public PlayerService(IPlayerRepo playerData)
        {
            _playerData = playerData;
        }

        public async Task CreatePlayer(string firstName, string lastName, bool gender, int federationNumber)
        {
            await _playerData.InsertPlayerAsync(firstName, lastName, gender, federationNumber);
        }

        public async Task<List<PlayersDTO>> FetchPlayersAsync()
        {
            var result = new List<PlayersDTO>();
            await foreach (PlayersDTO myPlayers in _playerData.FetchPlayersAsync())
            {
                result.Add(myPlayers);
            }
            return result;
        }
    }
}

