using System.ComponentModel.DataAnnotations;

namespace VesselTracking.Api.Models.Vessel
{
    public class VesselDto : BaseVesselDto
    {
        public int Id { get; set; }

    }

    public class CreateVesselDto : BaseVesselDto
    {

    }

    public abstract class BaseVesselDto
    {
        [Required]
        public string? Name { get; set; } //nullable string
        [Required]
        public string Type { get; set; }
        [Required]
        public string ImoNumber { get; set; }
        [Required]
        public int DockingPortId { get; set; }
    }
}
