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
    public class UserDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var UserDetails = await _unitOfWork.UserDetails.GetAll(includes: q => q.Include(x => x.Gender));
            return Ok(UserDetails);
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            var UserDetail = await _unitOfWork.UserDetails.Get(q => q.Id == id);

            if (UserDetail == null)
            {
                return NotFound();
            }

            return UserDetail;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail UserDetail)
        {
            if (id != UserDetail.Id)
            {
                return BadRequest();
            }

            _unitOfWork.UserDetails.Update(UserDetail);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserDetailExists(id))
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

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail UserDetail)
        {
            await _unitOfWork.UserDetails.Insert(UserDetail);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUserDetail", new { id = UserDetail.Id }, UserDetail);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            var UserDetail = await _unitOfWork.UserDetails.Get(q => q.Id == id);
            if (UserDetail == null)
            {
                return NotFound();
            }

            await _unitOfWork.UserDetails.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> UserDetailExists(int id)
        {
            var UserDetail = await _unitOfWork.UserDetails.Get(q => q.Id == id);
            return UserDetail != null;
        }
    }
}
