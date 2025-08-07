using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Contracts;
using VesselTracking.Api.Data;

namespace VesselTracking.Api.Repository
{
    public class PortsRepository : GenericRepository<Port>, IPortsRepository
    {
        private readonly VesselTrackingDbContext _context;

        public PortsRepository(VesselTrackingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Port> GetDetails(int id)
        {
            return await _context.Ports.Include(q => q.Vessels)
                .FirstOrDefaultAsync(q => q.DockingPortId == id);

        }
    }
}
