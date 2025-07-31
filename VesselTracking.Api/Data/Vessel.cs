namespace VesselTracking.Api.Data
{
    public class Vessel
    {
        public int Id {  get; set; }

        public string? Name { get; set; } //nullable string

        public string Type { get; set; }

        public string OriginCountry { get; set; }

        public string ImoNumber { get; set; }

        public int BuiltYear { get; set; }

        public int DeadWeight { get; set; }

        public DockingPort? Docking_port {  get; set; }
    }
}
