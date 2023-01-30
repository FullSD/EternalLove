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
    public class GendersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GendersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var Genders = await _unitOfWork.Genders.GetAll();
            return Ok(Genders);
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var Gender = await _unitOfWork.Genders.Get(q => q.Id == id);

            if (Gender == null)
            {
                return NotFound();
            }

            return Gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, Gender Gender)
        {
            if (id != Gender.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Genders.Update(Gender);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GenderExists(id))
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

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender Gender)
        {
            await _unitOfWork.Genders.Insert(Gender);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGender", new { id = Gender.Id }, Gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var Gender = await _unitOfWork.Genders.Get(q => q.Id == id);
            if (Gender == null)
            {
                return NotFound();
            }

            await _unitOfWork.Genders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> GenderExists(int id)
        {
            var Gender = await _unitOfWork.Genders.Get(q => q.Id == id);
            return Gender != null;
        }
    }
}
