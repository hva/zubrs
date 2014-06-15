using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataRepository : IDataRepository
    {
        [Inject]
        public ZubrsContext Context { get; set; }

        public async Task<IEnumerable<Competition>> GetCompetitionsAsync()
        {
            return await Context.Competitions.ToArrayAsync();
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            return Context.Competitions.ToArray();
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await Context.Teams.ToArrayAsync();
        }

        public IEnumerable<Team> GetTeams()
        {
            return Context.Teams.ToArray();
        }

        public async Task<IEnumerable<Game>> GetVisibleGamesAsync()
        {
            return await Context.Games.ToArrayAsync();
        }
    }
}