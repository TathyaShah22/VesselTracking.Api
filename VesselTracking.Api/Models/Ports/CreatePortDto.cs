using Microsoft.IdentityModel.Tokens;

namespace VesselTracking.Api.Models.Ports
{
    public class CreatePortDto : BasePortDto
    {
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int capacityDeadweight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
