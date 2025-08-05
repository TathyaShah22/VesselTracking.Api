using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Models;

namespace VesselTracking.Api.Data
{
    public partial class VesselTrackingDbContext : DbContext
    {
        public VesselTrackingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Port> Ports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Ports
            modelBuilder.Entity<Port>().HasData(
                new Port
                {
                    DockingPortId = 1,
                    Name = "Khalifa Port",
                    Country = "UAE",
                    IsAvailable = true,
                    capacityDeadweight = 100000
                },
                new Port
                {
                    DockingPortId = 2,
                    Name = "Zayed Port",
                    Country = "UAE",
                    IsAvailable = false,
                    capacityDeadweight = 50000
                }
            );

            // Seed data for Vessels
            modelBuilder.Entity<Vessel>().HasData(
                new Vessel
                {
                    Id = 1,
                    Name = "Marine Explorer",
                    Type = "LNG",
                    OriginCountry = "India",
                    ImoNumber = "IMO7654321",
                    BuiltYear = 2015,
                    DeadWeight = 74000,
                    DockingPortId = 1 // FK to Port
                },
                new Vessel
                {
                    Id = 2,
                    Name = "Ocean Voyager",
                    Type = "Cargo",
                    OriginCountry = "USA",
                    ImoNumber = "IMO1234567",
                    BuiltYear = 2010,
                    DeadWeight = 60000,
                    DockingPortId = 2
                }
            );
            //configuring the vessel to port relationship explicitly
            modelBuilder.Entity<Vessel>()
               .HasOne(v => v.DockingPort)
               .WithMany(p => p.Vessels)
               .HasForeignKey(v => v.DockingPortId)
               .IsRequired();
        }
    }
}
