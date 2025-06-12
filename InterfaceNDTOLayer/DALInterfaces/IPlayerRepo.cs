using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPlayerRepo
    {
        Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email);
        IAsyncEnumerable<PlayersDTO> FetchPlayersAsync();
        Task UpdatePlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email);
        Task<PlayersDTO?> GetByFederationNumberAsync(int federationNumber);
        Task<PlayersDTO?> FetchPlayerByIdAsync(int id);
    }
}
