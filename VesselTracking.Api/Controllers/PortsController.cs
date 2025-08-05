using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Data;
using AutoMapper;
using VesselTracking.Api.Models.Ports;
using VesselTracking.Api.Contracts;


namespace VesselTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortsController : ControllerBase
    {
        //private readonly VesselTrackingDbContext _context;
        private readonly IMapper _mapper;
        private readonly iPortsRepository _portsRepository;

        public PortsController(IMapper mapper, iPortsRepository portsRepository)
        {
            this._portsRepository = portsRepository;
            this._mapper = mapper;
        }

        // GET: api/Ports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPortDto>>> GetPorts()
        {
            var ports = await _portsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetPortDto>>(ports);
            return Ok(records);
        }

        // GET: api/Ports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPortDto>> GetPort(int id)
        {
            var port = await _portsRepository.GetDetails(id);
            if (port == null)
            {
                return NotFound();
            }

            var portDto = _mapper.Map<PortDto>(port);
            return Ok(portDto);
        }

        // PUT: api/Ports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPort(int id, UpdatedPortDto updatedPortDto)
        {
            if (id != updatedPortDto.DockingPortID)
            {
                return BadRequest("Invalid Record Id");
            }

            ////_context.Entry(updatedPortDto).State = EntityState.Modified;

            var port = await _portsRepository.GetAsync(id);
            if (port == null) {
                return NotFound();
                    }

            _mapper.Map(updatedPortDto, port);


            try
            {
                await _portsRepository.UpdateAsync(port);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PortExists(id))
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

        // POST: api/Ports
        [HttpPost]
        public async Task<ActionResult<GetPortDto>> PostPort(CreatePortDto createPort)
        {
            var port = _mapper.Map<Port>(createPort);

            await _portsRepository.AddAsync(port);

            var portDto = _mapper.Map<GetPortDto>(port);

            return CreatedAtAction(nameof(GetPort), new { id = port.DockingPortId }, portDto);
        }

        // DELETE: api/Ports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePort(int id)
        {
            var port = await _portsRepository.GetAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            await _portsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> PortExists(int id)
        {
            return await _portsRepository.Exists(id);
        }
    }
}
