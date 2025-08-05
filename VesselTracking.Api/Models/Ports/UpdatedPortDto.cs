namespace VesselTracking.Api.Models.Ports
{
    public class UpdatedPortDto : BasePortDto
    {
        public int DockingPortID { get; internal set; }
    }
}
