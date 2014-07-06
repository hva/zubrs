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
            foreach (var rank in newTable.Values)
            {
                rank.SeasonId = seasonId;
                Ranks.Add(rank);
            }
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

        private Dictionary<int, Rank> GetNewTable(int seasonId)
        {
            var table = new Dictionary<int, Rank>(); // teamId => rank
            var games = Games
                .Where(x => x.SeasonId == seasonId)
                .Where(x => x.HomeScore > 0 || x.AwayScore > 0).ToArray();
            foreach (var game in games)
            {
                bool isHomeWon = game.HomeScore > game.AwayScore;
                table.IncRank(game.HomeId, isHomeWon);
                table.IncRank(game.AwayId, !isHomeWon);
            }
            return table;
        }
    }
}
