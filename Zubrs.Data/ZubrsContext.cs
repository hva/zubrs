using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Zubrs.Extensions;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class ZubrsContext : DbContext
    {
        public ZubrsContext()
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Video> Videos { get; set; }

        public void RefreshSeasonRanks(int seasonId)
        {
            var oldTable = Ranks.Where(x => x.SeasonId == seasonId).ToArray();
            Ranks.RemoveRange(oldTable);

            var newTable = GetNewTable(seasonId);
            int place = 1;
            var newItems =
                from x in newTable
                orderby x.Value descending
                select new Rank
                {
                    Place = place++,
                    Points = x.Value,
                    SeasonId = seasonId,
                    TeamId = x.Key
                };

            Ranks.AddRange(newItems);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasRequired(g => g.Home)
                .WithMany()
                .HasForeignKey(g => g.HomeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasRequired(g => g.Away)
                .WithMany()
                .HasForeignKey(g => g.AwayId)
                .WillCascadeOnDelete(false);
        }

        private Dictionary<int, int> GetNewTable(int seasonId)
        {
            const int pointsForWin = 3;
            var table = new Dictionary<int, int>(); // teamId => points
            var games = Games.Where(x => x.SeasonId == seasonId).ToArray();
            foreach (var game in games)
            {
                int homePoints = game.HomeScore > game.AwayScore ? pointsForWin : 0;
                int awayPoints = pointsForWin - homePoints;
                table.IncValue(game.HomeId, homePoints);
                table.IncValue(game.AwayId, awayPoints);
            }
            return table;
        }
    }
}
