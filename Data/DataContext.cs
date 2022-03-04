using Microsoft.EntityFrameworkCore;
using net_reference.Models;

namespace net_reference.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Player>? Players { get; set; }

        public DbSet<PlayerPosition>? PlayerPositions { get; set; }

        public DbSet<Team>? Teams { get; set; }


    }
}
