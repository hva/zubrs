using System;
using System.Linq;
using System.Threading.Tasks;
using Zubrs.Models;

namespace Zubrs.Data
{
    public interface IDataRepository
    {
        IQueryable<Competition> Competitions { get; }
        IQueryable<Team> Teams { get; }
        IQueryable<Game> Games { get; }
        IQueryable<Article> Articles { get; }
        IQueryable<Video> Videos { get; }

        void SetLog(Action<string> log);
        Task RefreshSeasonRanksAsync(Season season);
    }
}