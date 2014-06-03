using System.Collections.Generic;
using System.Threading.Tasks;
using Zubrs.Models;

namespace Zubrs.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Competition>> GetCompetitionsAsync();
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<IEnumerable<Game>> GetGamesAsync();
    }
}