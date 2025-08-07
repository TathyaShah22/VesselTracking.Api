using VesselTracking.Api.Contracts;
using VesselTracking.Api.Data;

namespace VesselTracking.Api.Repository
{
    public class VesselsRepository : GenericRepository<Vessel>, IVesselsRepository
    {
        public VesselsRepository(VesselTrackingDbContext context) : base(context)
        {
        }
    }
}
