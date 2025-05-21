using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using InterfaceLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TeamManager
    {
        private readonly ITeamData _data;

        public TeamManager(ITeamData data)
        {
            _data = data;
        }

        public Task<List<DTOTeam>> GetTeamsAsync()
        {
            return _data.GetAllTeamsAsync();
        }

        public Task AddTeamAsync(string name)
        {
            return _data.AddTeamAsync(name);
        }
    }
}
