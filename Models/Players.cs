using Microsoft.EntityFrameworkCore;
using net_reference.Seed.Models;

namespace net_reference.Models
{
    public class Players
    {
        public void CalculateAttributes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
               .Property(u => u.NameNId)
               .HasComputedColumnSql("cast([Id] as varchar(5)) + ' ' + [Name]");

            modelBuilder.Entity<Player>()
               .Property(u => u.NameNTeamId)
               .HasComputedColumnSql("cast([TeamId] as varchar(5)) + ' ' + [Name]");


        }

    }
}
