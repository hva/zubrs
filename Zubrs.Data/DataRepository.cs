using System;
using System.Linq;
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
        public IQueryable<Article> Articles { get { return Context.Articles; } }
        public IQueryable<Video> Videos { get { return Context.Videos; } }
    }
}