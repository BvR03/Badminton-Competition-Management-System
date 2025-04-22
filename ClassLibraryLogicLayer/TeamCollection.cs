using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class TeamCollection
    {
        private List<Team> teams = new List<Team>();
        public void CreateTeam(string name)
        {
            Team team = new Team(name);

        }
        public List<Team> GetAllTeams()
        {
            return teams;
        }

    }
}
