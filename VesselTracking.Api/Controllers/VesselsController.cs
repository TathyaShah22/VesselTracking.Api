using Microsoft.AspNetCore.Mvc;
using VesselTracking.Api.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VesselTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  VesselsController : ControllerBase
    {

        private static List<Vessel> vessels = new List<Vessel>
{
    new Vessel
    {
        Id = 1,
        Name = "Ocean Voyager",
        Type = "Container",
        OriginCountry = "UAE",
        ImoNumber = "IMO1234567",
        BuiltYear = 2010,
        DeadWeight = 52000,
        },
    new Vessel
    {
        Id = 2,
        Name = "Marine Explorer",
        Type = "LNG",
        OriginCountry = "India",
        ImoNumber = "IMO7654321",
        BuiltYear = 2015,
        DeadWeight = 74000,
    },
    new Vessel
    {
        Id = 3,
        Name = "Blue Horizon",
        Type = "Passenger",
        OriginCountry = "USA",
        ImoNumber = "IMO1122334",
        BuiltYear = 2005,
        DeadWeight = 30000,
    }
};

        // GET: api/<VesselsController>
        [HttpGet]
        public ActionResult<IEnumerable<Vessel>> Get()
        {
            return Ok(vessels);
        }

        // GET api/<VesselsController>/5
        [HttpGet("{id}")]
        public ActionResult<Vessel> Get(int id)
        {
            var vessel = vessels.FirstOrDefault(v=>v.Id == id);
            if(vessel == null)
            {
                return NotFound();
            }

            return Ok(vessel);
        }

        // POST api/<VesselsController>
        [HttpPost]
        public ActionResult<Vessel> Post([FromBody] Vessel newVessel)
        {
            if(vessels.Any(v => v.Id == newVessel.Id))
            {
                return BadRequest("Vessel with this Id already exists");
            }

            vessels.Add(newVessel);
            return CreatedAtAction(nameof(Get), new {id = newVessel.Id}, newVessel);
        }

        // PUT api/<VesselsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Vessel updatedVessel)
        {
            var existingVessel = vessels.FirstOrDefault(v => v.Id == id);
            if (existingVessel == null)
            {
                return NotFound();
            }

            // Update fields
            existingVessel.Name = updatedVessel.Name;
            existingVessel.Type = updatedVessel.Type;
            existingVessel.OriginCountry = updatedVessel.OriginCountry;
            existingVessel.ImoNumber = updatedVessel.ImoNumber;
            existingVessel.BuiltYear = updatedVessel.BuiltYear;
            existingVessel.DeadWeight = updatedVessel.DeadWeight;

            return NoContent(); // 204 No Content.
        }

        // DELETE api/<VesselsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var vessel = vessels.FirstOrDefault(v => v.Id == id);
            if (vessel == null)
            {
                return NotFound(new { message = "Vessel not found" });  //error 404              
            }

            vessels.Remove(vessel);
            return NoContent(); 

        }
    }
}
