using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Data;

namespace VesselTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DockingPortsController : ControllerBase
    {
        private readonly VesselTrackingDbContext _context;

        public DockingPortsController(VesselTrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/DockingPorts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DockingPort>>> GetDockingPort()
        {
            var ports = await _context.DockingPort.ToListAsync();
            return Ok(ports);
        }

        // GET: api/DockingPorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DockingPort>> GetDockingPort(int id)
        {
            var dockingPort = await _context.DockingPort.FindAsync(id);

            if (dockingPort == null)
            {
                return NotFound();
            }

            return Ok(dockingPort);
        }

        // PUT: api/DockingPorts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDockingPort(int id, DockingPort dockingPort)
        {
            if (id != dockingPort.DockingPortId)
            {
                return BadRequest();
            }

            _context.Entry(dockingPort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DockingPortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DockingPorts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DockingPort>> PostDockingPort(DockingPort dockingPort)
        {
            _context.DockingPort.Add(dockingPort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDockingPort", new { id = dockingPort.DockingPortId }, dockingPort);
        }

        // DELETE: api/DockingPorts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDockingPort(int id)
        {
            var dockingPort = await _context.DockingPort.FindAsync(id);
            if (dockingPort == null)
            {
                return NotFound();
            }

            _context.DockingPort.Remove(dockingPort);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DockingPortExists(int id)
        {
            return _context.DockingPort.Any(e => e.DockingPortId == id);
        }
    }
}
