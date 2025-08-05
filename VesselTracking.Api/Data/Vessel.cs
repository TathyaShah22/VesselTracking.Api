using System.ComponentModel.DataAnnotations.Schema;

namespace VesselTracking.Api.Data
{
    public class Vessel
    {
        public int Id { get; set; }

        public string? Name { get; set; } // Nullable string

        public string Type { get; set; }

        public string OriginCountry { get; set; }

        public string ImoNumber { get; set; }

        public int BuiltYear { get; set; }

        public int DeadWeight { get; set; }

        public int DockingPortId { get; set; }  // Foreign key property

        [ForeignKey(nameof(DockingPortId))]
        public Port? DockingPort { get; set; }  // Navigation property (PascalCase)
    }
}
