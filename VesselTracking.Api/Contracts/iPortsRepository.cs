using VesselTracking.Api.Data;

namespace VesselTracking.Api.Contracts
{
    public interface iPortsRepository : iGenericRepository<Port>
    {
        Task<Port> GetDetails(int id);
    }
}
