using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Extensions;
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
        public IQueryable<Article> Articles { get { return Context.Articles; } }
        public IQueryable<Video> Videos { get { return Context.Videos; } }

        public async Task RefreshSeasonRanksAsync(Season season)
        {
            const int pointsForWin = 3;
            var table = new Dictionary<int, int>(); // teamId => points
            var games = await Games.Where(x => x.Season == season).ToArrayAsync();
            foreach (var game in games)
            {
                int homePoints = game.HomeScore > game.AwayScore ? pointsForWin : 0;
                int awayPoints = pointsForWin - homePoints;
                table.IncValue(game.HomeId, homePoints);
                table.IncValue(game.AwayId, awayPoints);
            }
        }
    }
}