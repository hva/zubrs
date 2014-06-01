using System.Collections.Generic;
using System.Threading.Tasks;
using Zubrs.Mvc.Models;

namespace Zubrs.Mvc.Data
{
    public interface IRepository
    {
        Task<IEnumerable<Competition>> GetCompetitionsAsync();
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<IEnumerable<Game>> GetGamesAsync();
    }
}