using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Models;

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


}
