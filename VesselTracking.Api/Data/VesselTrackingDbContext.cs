using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Models;
using VesselTracking.Api.Data;

namespace VesselTracking.Api.Data;

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

public DbSet<VesselTracking.Api.Data.DockingPort> DockingPort { get; set; } = default!;


}
