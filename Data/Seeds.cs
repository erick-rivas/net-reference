using Microsoft.EntityFrameworkCore;
using net_reference.Models;


public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerPosition>().HasData(
            new PlayerPosition { Id = 1, Name = "Left Wing", Details = "" },
            new PlayerPosition { Id = 2, Name = "Striker", Details = "" }
        );

        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Real Madrid", Description = "El mejor equipo del mundo", MarketValue = 100000 },
            new Team { Id = 2, Name = "Barcelona", Description = "Podría ser mejor", MarketValue = 100, RivalId = 1 }

        );

        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Vinicius JR", IsActive = true, TeamId = 1, PlayerPositionId = 1 },
            new Player { Id = 2, Name = "Hugo Sánchez", IsActive = false, TeamId = 1, PlayerPositionId = 2 }

        );
    }
}