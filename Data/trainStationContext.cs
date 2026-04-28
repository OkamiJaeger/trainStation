using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trainStation.Model;

namespace trainStation.Data
{
    public class trainStationContext : DbContext
    {
        public trainStationContext (DbContextOptions<trainStationContext> options)
            : base(options)
        {
        }

        public DbSet<trainStation.Model.Train> Train { get; set; } = default!;
        public DbSet<trainStation.Model.Schedule> Schedule { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Data for Train Table
            modelBuilder.Entity<Train>().HasData(
                new Train {
                    Id = 1,
                    Name = "Zermatt-St.Moritz", 
                    Company = "Glacier Express", 
                    Service = ServiceType.Passenger, 
                    Length = 160 
                },
                new Train {
                    Id = 2,
                    Name = "BNSF Transcon",
                    Company = "BNSF Railway",
                    Service = ServiceType.Freight,
                    Cargo = CargoType.Boxcar,
                    Length = 2000,
                    Mass = 15000
                },
                new Train {
                    Id = 3,
                    Name = "Shinkansen Nozomi",
                    Company = "JR Central",
                    Service = ServiceType.Passenger,
                    Cargo = CargoType.None,
                    Length = 400.0,
                }
                );

            //Seed data for the schedule table
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule {
                    Id = 1,
                    Arrival = new DateTime(2026, 5, 1, 8, 0, 0),
                    Departure = new DateTime(2026, 5, 1, 8, 15, 0),
                    Platform = PlatformType.Platform1,
                    TrainID = 1
                },
                new Schedule
                {
                    Id = 2,
                    Arrival = new DateTime(2026, 5, 1, 9, 30, 0),
                    Departure = new DateTime(2026, 5, 1, 10, 0, 0),
                    Platform = PlatformType.Platform3,
                    TrainID = 2
                },
                new Schedule
                {
                    Id = 3,
                    Arrival = new DateTime(2026, 5, 1, 11, 45, 0),
                    Departure = null,
                    Platform = PlatformType.MaintenanceHouse,
                    TrainID = 3
                }
                );
        }
    }
}
