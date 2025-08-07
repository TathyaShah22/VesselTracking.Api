using VesselTracking.Api.Data;

namespace VesselTracking.Api.Contracts
{
    public interface IPortsRepository : IGenericRepository<Port>
    {
        Task<Port> GetDetails(int id);
    }
}
