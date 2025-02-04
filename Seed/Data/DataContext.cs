﻿using Microsoft.EntityFrameworkCore;
using net_reference.Seed.Models;
using net_reference.Models;

namespace net_reference.Seed.Data
{
    public class DataContext : DbContext

    {
        private readonly Players _players = new Players();
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            _players.CalculateAttributes(modelBuilder);


        }

        public DbSet<Player>? Players { get; set; }

        public DbSet<Players>? Player { get; set; }


        public DbSet<PlayerPosition>? PlayerPositions { get; set; }

        public DbSet<Team>? Teams { get; set; }

    }
}
