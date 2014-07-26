using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ninject;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataRepository : IDataRepository
    {
        [Inject]
        public ZubrsContext Context { get; set; }

        public void SetLog(Action<string> log)
        {
            Context.Database.Log = log;
        }

        public IQueryable<Competition> Competitions { get { return Context.Competitions; } }
        public IQueryable<Team> Teams { get { return Context.Teams; } }
        public IQueryable<Game> Games { get { return Context.Games; } }
        public IQueryable<Player> Players { get { return Context.Players; } }
        public IQueryable<Rank> Ranks { get { return Context.Ranks; } }
        public IQueryable<Article> Articles { get { return Context.Articles; } }
        public IQueryable<Video> Videos { get { return Context.Videos; } }

        public async Task LoadPlayersAsync(Team team)
        {
            await Context.Entry(team).Collection(x => x.Players).LoadAsync();
        }

        public async Task LoadGamesAsync(Season season)
        {
            await Context.Entry(season)
                .Collection(x => x.Games)
                .Query()
                .Include(x => x.Home)
                .Include(x => x.Away)
                .LoadAsync();
        }
    }
}