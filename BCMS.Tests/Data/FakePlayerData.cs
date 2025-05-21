using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceLayer;

public class FakePlayerData : IPlayerData
{
    public List<(string firstName, string lastName, bool gender, int federationNumber)> InsertedPlayers { get; } = new();

    public async Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber)
    {
        InsertedPlayers.Add((firstName, lastName, gender, federationNumber));
        await Task.CompletedTask;
    }

    private List<DTOPlayers> _playersToReturn = new();

    public void SetPlayers(List<DTOPlayers> players)
    {
        _playersToReturn = players;
    }

    public async IAsyncEnumerable<DTOPlayers> FetchPlayersAsync()
    {
        foreach (var p in _playersToReturn)
        {
            yield return p;
            await Task.Yield();
        }
    }
}
