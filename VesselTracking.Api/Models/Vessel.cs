using System;
using System.Collections.Generic;

namespace VesselTracking.Api.Models;

public partial class Vessel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Type { get; set; } = null!;

    public string OriginCountry { get; set; } = null!;

    public string ImoNumber { get; set; } = null!;

    public int BuiltYear { get; set; }

    public int DeadWeight { get; set; }

    public int? DockingPortDockingPortId { get; set; }

    public virtual Port? DockingPortDockingPort { get; set; }
}
