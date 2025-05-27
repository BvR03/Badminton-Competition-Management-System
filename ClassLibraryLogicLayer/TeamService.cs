using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using InterfaceLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TeamService
    {
        private readonly ITeamRepo _data;

        public TeamService(ITeamRepo data)
        {
            _data = data;
        }

        public Task<List<TeamDTO>> GetTeamsAsync()
        {
            return _data.GetAllTeamsAsync();
        }

        public Task AddTeamAsync(string name)
        {
            return _data.AddTeamAsync(name);
        }
    }
}
