using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataRepository : IDataRepository
    {
        public async Task<IEnumerable<Competition>> GetCompetitionsAsync()
        {
            using (var context = new ZubrsContext())
            {
                return await context.Competitions.ToArrayAsync();
            }
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            using (var context = new ZubrsContext())
            {
                return context.Competitions.ToArray();
            }
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            using (var context = new ZubrsContext())
            {
                return await context.Teams.ToArrayAsync();
            }
        }

        public IEnumerable<Team> GetTeams()
        {
            using (var context = new ZubrsContext())
            {
                return context.Teams.ToArray();
            }
        }

        public Task<IEnumerable<Game>> GetGamesAsync()
        {
            return Task.FromResult(LoadGames());
        }

        private IEnumerable<Game> LoadGames()
        {
            yield return new Game
            {
                Id = 1,
                CompetitionId = 1,
                Date = new DateTime(2013, 10, 25, 12, 0, 0),
                HomeId = 1,
                AwayId = 2,
                HomeScore = 12,
                AwayScore = 4,
            };
            yield return new Game
            {
                Id = 2,
                CompetitionId = 1,
                Date = new DateTime(2013, 10, 25, 15, 0, 0),
                HomeId = 5,
                AwayId = 3,
                HomeScore = 13,
                AwayScore = 10,
            };
            yield return new Game
            {
                Id = 3,
                CompetitionId = 1,
                Date = new DateTime(2013, 10, 26, 12, 0, 0),
                HomeId = 2,
                AwayId = 5,
                HomeScore = 13,
                AwayScore = 3,
            };
            yield return new Game
            {
                Id = 4,
                CompetitionId = 1,
                Date = new DateTime(2013, 10, 25, 15, 0, 0),
                HomeId = 1,
                AwayId = 3,
                HomeScore = 14,
                AwayScore = 4,
            };
            yield return new Game
            {
                Id = 5,
                CompetitionId = 2,
                Date = new DateTime(2013, 10, 17, 12, 0, 0),
                HomeId = 3,
                AwayId = 4,
                HomeScore = 0,
                AwayScore = 20,
            };
            yield return new Game
            {
                Id = 6,
                CompetitionId = 2,
                Date = new DateTime(2013, 10, 17, 15, 0, 0),
                HomeId = 1,
                AwayId = 5,
                HomeScore = 12,
                AwayScore = 11,
            };
            yield return new Game
            {
                Id = 7,
                CompetitionId = 2,
                Date = new DateTime(2013, 10, 18, 12, 0, 0),
                HomeId = 3,
                AwayId = 1,
                HomeScore = 5,
                AwayScore = 7,
            };
            yield return new Game
            {
                Id = 8,
                CompetitionId = 2,
                Date = new DateTime(2013, 10, 18, 15, 0, 0),
                HomeId = 4,
                AwayId = 5,
                HomeScore = 9,
                AwayScore = 2,
            };
            yield return new Game
            {
                Id = 9,
                CompetitionId = 2,
                Date = new DateTime(2013, 10, 19, 12, 0, 0),
                HomeId = 5,
                AwayId = 3,
                HomeScore = 0,
                AwayScore = 9,
            };
        }
    }
}