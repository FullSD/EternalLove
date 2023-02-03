using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EternalLove.Server.Data;
using EternalLove.Shared.Domain;
using EternalLove.Server.IRepository;

namespace EternalLove.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var Locations = await _unitOfWork.Locations.GetAll();
            return Ok(Locations);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var Location = await _unitOfWork.Locations.Get(q => q.Id == id);

            if (Location == null)
            {
                return NotFound();
            }

            return Location;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location Location)
        {
            if (id != Location.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Locations.Update(Location);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location Location)
        {
            await _unitOfWork.Locations.Insert(Location);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetLocation", new { id = Location.Id }, Location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var Location = await _unitOfWork.Locations.Get(q => q.Id == id);
            if (Location == null)
            {
                return NotFound();
            }

            await _unitOfWork.Locations.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> LocationExists(int id)
        {
            var Location = await _unitOfWork.Locations.Get(q => q.Id == id);
            return Location != null;
        }
    }
}
