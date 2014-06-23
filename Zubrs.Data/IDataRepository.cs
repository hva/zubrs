using System;
using System.Linq;
using Zubrs.Models;

namespace Zubrs.Data
{
    public interface IDataRepository
    {
        void SetLog(Action<string> log);

        IQueryable<Competition> Competitions { get; }
        IQueryable<Team> Teams { get; }
        IQueryable<Game> Games { get; }
        IQueryable<Article> Articles { get; }
    }
}