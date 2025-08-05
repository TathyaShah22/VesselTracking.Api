using VesselTracking.Api.Models.Vessel;

namespace VesselTracking.Api.Models.Ports
{
    public class PortDto
    {
        public int DockingPortId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;

        public List<VesselDto> Vessels { get; set; } 
    }

   
}
