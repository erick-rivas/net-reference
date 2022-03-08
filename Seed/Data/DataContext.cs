using Microsoft.EntityFrameworkCore;
using net_reference.Seed.Models;
using net_reference.Models;

namespace net_reference.Seed.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            Players player = new Players();

            player.CalculateAttributes(modelBuilder);

        }

        public DbSet<Player>? Players { get; set; }

        public DbSet<Players>? Player { get; set; }


        public DbSet<PlayerPosition>? PlayerPositions { get; set; }

        public DbSet<Team>? Teams { get; set; }

    }
}
