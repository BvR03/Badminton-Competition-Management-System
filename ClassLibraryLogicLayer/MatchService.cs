using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using InterfaceLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MatchService
    {
        private readonly IMatchRepo _matchRepo;
        private readonly IPlayerRepo _playerRepo;

        public MatchService(IMatchRepo matchRepo, IPlayerRepo playerRepo)
        {
            _matchRepo = matchRepo;
            _playerRepo = playerRepo;
        }

        public async Task<List<MatchDTO>> FetchMatchesByPlayerIdAsync(int playerId)
        {
            var matches = new List<MatchDTO>();

            await foreach (var match in _matchRepo.FetchMatchesAsync())
            {
                if (match.PlayerID == playerId || match.PlayerIDP2 == playerId)
                {
                    var player1 = await _playerRepo.FetchPlayerByIdAsync(match.PlayerID);
                    match.Player1Name = player1 != null ? $"{player1.FirstName} {player1.LastName}" : "-";

                    if (match.PlayerIDP2.HasValue)
                    {
                        var partner = await _playerRepo.FetchPlayerByIdAsync(match.PlayerIDP2.Value);
                        match.PartnerName = partner != null ? $"{partner.FirstName} {partner.LastName}" : "-";
                    }

                    matches.Add(match);
                }
            }

            return matches;
        }
    }
}
