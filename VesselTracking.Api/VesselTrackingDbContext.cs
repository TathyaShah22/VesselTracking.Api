using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VesselTracking.Api;

public partial class VesselTrackingDbContext : DbContext
{
    public VesselTrackingDbContext()
    {
    }

    public VesselTrackingDbContext(DbContextOptions<VesselTrackingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Port> Ports { get; set; }

    public virtual DbSet<Vessel> Vessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=VesselTrackingDb;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Port>(entity =>
        {
            entity.HasKey(e => e.DockingPortId);

            entity.Property(e => e.CapacityDeadweight).HasColumnName("capacityDeadweight");
        });

        modelBuilder.Entity<Vessel>(entity =>
        {
            entity.HasIndex(e => e.DockingPortDockingPortId, "IX_Vessels_Docking_portDockingPortId");

            entity.Property(e => e.DockingPortDockingPortId).HasColumnName("Docking_portDockingPortId");

            entity.HasOne(d => d.DockingPortDockingPort).WithMany(p => p.Vessels).HasForeignKey(d => d.DockingPortDockingPortId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
