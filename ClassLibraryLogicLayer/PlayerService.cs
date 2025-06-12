using DAL;
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

        public async Task CreatePlayer(string firstName, string lastName, bool gender, int federationNumber, string email)
        {
            await _playerData.InsertPlayerAsync(firstName, lastName, gender, federationNumber, email);
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

        public async Task UpdatePlayerByFederationNumber(string firstName, string lastName, bool gender, int federationNumber, string email)
        {
            await _playerData.UpdatePlayerAsync(firstName, lastName, gender, federationNumber, email);
        }
        public async Task<PlayersDTO?> FetchPlayerByFederationNumberAsync(int fedNumber)
        {
            return await _playerData.GetByFederationNumberAsync(fedNumber);
        }

    }
}

