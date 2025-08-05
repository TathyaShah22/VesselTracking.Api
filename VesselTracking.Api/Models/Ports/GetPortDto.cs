using System.ComponentModel.DataAnnotations.Schema;
using VesselTracking.Api.Data;

namespace VesselTracking.Api.Models.Ports
{
    public class GetPortDto : BasePortDto
    {
        public int DockingPortId { get; set; }

    }
}