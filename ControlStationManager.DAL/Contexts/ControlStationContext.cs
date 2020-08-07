using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ControlStationManager.DAL.Contexts
{
    public class ControlStationContext : DbContext
    {
        public DbSet<ControlStation> ControlStations { get; set; }
        public DbSet<StationItem> StationItems { get; set; }
        public DbSet<User> Users { get; set; }

        public ControlStationContext(DbContextOptions<ControlStationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed control stations
            modelBuilder.Entity<ControlStation>().HasData(
                new ControlStation { Id = -1, Name = "Aleksinac 1" },
                new ControlStation { Id = -2, Name = "Beograd" },
                new ControlStation { Id = -3, Name = "Kragujevac" }
                );

            // seed fire extinguishers
            modelBuilder.Entity<StationItem>().HasData(
                new StationItem
                {
                    Id = -1,
                    LastCheckDate = new DateTime(2020, 2, 1),
                    NextCheckDate = new DateTime(2020, 8, 1),
                    ControlStationId = -1
                },
                new StationItem
                {
                    Id = -2,
                    LastCheckDate = new DateTime(2020, 6, 1),
                    NextCheckDate = new DateTime(2020, 12, 1),
                    ControlStationId = -1
                });
        }

    }
}
