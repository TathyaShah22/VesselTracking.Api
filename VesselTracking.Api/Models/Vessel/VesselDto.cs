namespace VesselTracking.Api.Models.Vessel
{
    public class VesselDto
    {
        public int Id { get; set; }

        public string? Name { get; set; } //nullable string

        public string Type { get; set; }

        public string ImoNumber { get; set; }

        public int DockingPortId { get; set; }
    }
}
