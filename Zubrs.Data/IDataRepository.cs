using System;
using System.Linq;
using System.Threading.Tasks;
using Zubrs.Models;

namespace Zubrs.Data
{
    public interface IDataRepository
    {
        void SetLog(Action<string> log);

        IQueryable<Competition> Competitions { get; }
        IQueryable<Season> Seasons { get; }
        IQueryable<Team> Teams { get; }
        IQueryable<Game> Games { get; }
        IQueryable<Rank> Ranks { get; }
        IQueryable<Player> Players { get; }
        IQueryable<Article> Articles { get; }
        IQueryable<Video> Videos { get; }

        Task LoadPlayersAsync(Team team);
        Task LoadGamesAsync(Season season);
        Task LoadRanksAsync(Season season);
    }
}