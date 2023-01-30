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
    public class MatchsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Matchs
        [HttpGet]
        public async Task<IActionResult> GetMatchs()
        {
            var Matchs = await _unitOfWork.Matchs.GetAll(includes: q => q.Include(x => x.UserDetail1).Include(x => x.UserDetail2));
            return Ok(Matchs);
        }

        // GET: api/Matchs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var Match = await _unitOfWork.Matchs.Get(q => q.Id == id);

            if (Match == null)
            {
                return NotFound();
            }

            return Match;
        }

        // PUT: api/Matchs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match Match)
        {
            if (id != Match.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Matchs.Update(Match);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MatchExists(id))
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

        // POST: api/Matchs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match Match)
        {
            await _unitOfWork.Matchs.Insert(Match);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMatch", new { id = Match.Id }, Match);
        }

        // DELETE: api/Matchs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var Match = await _unitOfWork.Matchs.Get(q => q.Id == id);
            if (Match == null)
            {
                return NotFound();
            }

            await _unitOfWork.Matchs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> MatchExists(int id)
        {
            var Match = await _unitOfWork.Matchs.Get(q => q.Id == id);
            return Match != null;
        }
    }
}
