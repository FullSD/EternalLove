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
    public class ReportsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reports
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var Reports = await _unitOfWork.Reports.GetAll(includes: q => q.Include(x => x.User));
            return Ok(Reports);
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(int id)
        {
            var Report = await _unitOfWork.Reports.Get(q => q.Id == id);

            if (Report == null)
            {
                return NotFound();
            }

            return Report;
        }

        // PUT: api/Reports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, Report Report)
        {
            if (id != Report.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Reports.Update(Report);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReportExists(id))
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

        // POST: api/Reports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report Report)
        {
            await _unitOfWork.Reports.Insert(Report);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetReport", new { id = Report.Id }, Report);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var Report = await _unitOfWork.Reports.Get(q => q.Id == id);
            if (Report == null)
            {
                return NotFound();
            }

            await _unitOfWork.Reports.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ReportExists(int id)
        {
            var Report = await _unitOfWork.Reports.Get(q => q.Id == id);
            return Report != null;
        }
    }
}