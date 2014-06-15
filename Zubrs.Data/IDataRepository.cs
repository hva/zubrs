using System.Collections.Generic;
using System.Threading.Tasks;
using Zubrs.Models;

namespace Zubrs.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Competition>> GetCompetitionsAsync();
        IEnumerable<Competition> GetCompetitions();

        Task<IEnumerable<Team>> GetTeamsAsync();
        IEnumerable<Team> GetTeams();

        Task<IEnumerable<Game>> GetVisibleGamesAsync();
    }
}