using System;
using System.Collections.Generic;

namespace VesselTracking.Api;

public partial class Port
{
    
    public int DockingPortId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int CapacityDeadweight { get; set; }

    public bool IsAvailable { get; set; }

    public virtual ICollection<Vessel> Vessels { get; set; } = new List<Vessel>();
}
