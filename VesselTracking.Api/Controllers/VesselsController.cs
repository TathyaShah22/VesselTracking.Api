using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselTracking.Api.Contracts;
using VesselTracking.Api.Data;
using VesselTracking.Api.Models.Vessel;

namespace VesselTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsController : ControllerBase
    {
        private readonly IVesselsRepository _vesselsRepository;
        private readonly IMapper _mapper;

        public VesselsController( IVesselsRepository vesselsRepository, IMapper mapper)
        {
            this._vesselsRepository = vesselsRepository;
            this._mapper = mapper;
        }

        // GET: api/Vessels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VesselDto>>> GetVessels()
        {
            var vessels =  await _vesselsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<VesselDto>>(vessels));   
        }

        // GET: api/Vessels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VesselDto>> GetVessel(int id)
        {
            var vessel = await _vesselsRepository.GetAsync(id);

            if (vessel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<VesselDto>>(vessel));
        }

        // PUT: api/Vessels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVessel(int id, VesselDto vesselDto)
        {
            if (id != vesselDto.Id)
            {
                return BadRequest();
            }

            

            var vessel = await _vesselsRepository.GetAsync(id);
            if (vessel == null)
            {
                return NotFound(); 
            }

            _mapper.Map(vesselDto, vessel);

            try
            {
                await _vesselsRepository.UpdateAsync(vessel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VesselExists(id))
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

        // POST: api/Vessels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vessel>> PostVessel(CreateVesselDto vesselDto)
        {
            var vessel = _mapper.Map<Vessel>(vesselDto);

            await _vesselsRepository.AddAsync(vessel);
            return CreatedAtAction("GetVessel", new { id = vessel.Id }, vessel);
        }

        // DELETE: api/Vessels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVessel(int id)
        {
            var vessel = await _vesselsRepository.GetAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }

            await _vesselsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> VesselExists(int id)
        {
            return await _vesselsRepository.Exists(id);
        }
    }
}
