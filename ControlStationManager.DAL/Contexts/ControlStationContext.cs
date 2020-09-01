using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

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


            //seed Users
            CreatePasswordHash("dusan11", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = 1,
                    Username = "Dusan",
                    FirstName = "Dusan",
                    LastName = "Glisic",
                    DateOfBirth = new DateTime(1992, 9, 27),
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    JobTitle = "engineer",
                    EmailAddress = "marcetic18@hotmail.com",
                    PhotoUrl = "https://randomuser.me/api/portraits/men/72.jpg"
                }); ;

            //seed control stations
            modelBuilder.Entity<ControlStation>().HasData(
                new ControlStation { Id = 1, Type = "GMRS", Address = "Bulevar Patrijarha Pavla 9", Name = "Aleksinac 1", UserId = 1 },
                new ControlStation { Id = 2, Type = "GMRS", Address = "Bulevar Oslobodjenja 156", Name = "Beograd", UserId = 1 },
                new ControlStation { Id = 3, Type = "MRS", Address = "Gandijeva 90", Name = "Kragujevac 2", UserId = 1 },
                new ControlStation { Id = 4, Type = "GMRS", Address = "Bulevar Nikole Tesle BB", Name = "Nis 1", UserId = 1 },
                new ControlStation { Id = 5, Type = "GMRS", Address = "Kisacka 66", Name = "Novi Sad 1", UserId = 1 },
                new ControlStation { Id = 6, Type = "GMRS", Address = "Paunova 19", Name = "Beograd 2", UserId = 1 },
                new ControlStation { Id = 7, Type = "MRS", Address = "Bulevar Zorana Djindjica 10", Name = "Beograd 3", UserId = 1 },
                new ControlStation { Id = 8, Type = "GMRS", Address = "Vrsacka 98", Name = "Novi Sad 2", UserId = 1 },
                new ControlStation { Id = 9, Type = "GMRS", Address = "Despota Stefana BB", Name = "Sabac 1", UserId = 1 },
                new ControlStation { Id = 10, Type = "GMRS", Address = "27. marta 45", Name = "Kragujevac 1", UserId = 1 }
                );

            // seed fire extinguishers
            modelBuilder.Entity<StationItem>().HasData(
                new StationItem
                {
                    Id = -1,
                    LastCheckDate = new DateTime(2020, 2, 1),
                    NextCheckDate = new DateTime(2020, 8, 1),
                    ControlStationId = 1,
                    UserId = 1
                },
                new StationItem
                {
                    Id = -2,
                    LastCheckDate = new DateTime(2020, 6, 1),
                    NextCheckDate = new DateTime(2020, 12, 1),
                    ControlStationId = 1,
                    UserId = 1
                });

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
