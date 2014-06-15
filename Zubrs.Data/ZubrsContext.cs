using System.Data.Entity;
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
        public DbSet<Game> Games { get; set; }

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
    }
}
