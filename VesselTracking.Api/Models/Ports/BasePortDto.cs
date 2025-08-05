using System.ComponentModel.DataAnnotations;

namespace VesselTracking.Api.Models.Ports
{
    public abstract class BasePortDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int capacityDeadweight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
