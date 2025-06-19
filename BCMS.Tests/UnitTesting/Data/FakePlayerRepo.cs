using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceLayer;

public class FakePlayerRepo : IPlayerRepo
{
    public List<(string firstName, string lastName, bool gender, int federationNumber, string email)> InsertedPlayers { get; } = new();

    public async Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email)
    {
        InsertedPlayers.Add((firstName, lastName, gender, federationNumber, email));
        await Task.CompletedTask;
    }

    private List<PlayersDTO> _playersToReturn = new();

    public void SetPlayers(List<PlayersDTO> players)
    {
        _playersToReturn = players;
    }

    public async IAsyncEnumerable<PlayersDTO> FetchPlayersAsync()
    {
        foreach (var p in _playersToReturn)
        {
            yield return p;
            await Task.Yield();
        }
    }
    public async Task UpdatePlayerAsync(string firstName, string lastName, bool gender, int federationNumber, string email)
    {
        
    }
    public Task<PlayersDTO?> GetByFederationNumberAsync(int federationNumber)
    {
        var player = _playersToReturn.Find(p => p.FederationNumber == federationNumber);
        return Task.FromResult<PlayersDTO?>(player);
    }
    public Task<PlayersDTO?> FetchPlayerByIdAsync(int id)
    {
        var player = _playersToReturn.Find(p => p.ID == id);
        return Task.FromResult<PlayersDTO?>(player);
    }
}
