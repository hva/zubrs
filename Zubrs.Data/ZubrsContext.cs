using System.Data.Entity;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class ZubrsContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
    }
}
