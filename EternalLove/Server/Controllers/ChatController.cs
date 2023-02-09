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
    public class ChatsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Chats
        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var Chats = await _unitOfWork.Chats.GetAll(includes: q => q.Include(x => x.UserDetail1).Include(x => x.UserDetail2));
            return Ok(Chats);
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var Chat = await _unitOfWork.Chats.Get(q => q.Id == id);

            if (Chat == null)
            {
                return NotFound();
            }

            return Chat;
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, Chat Chat)
        {
            if (id != Chat.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Chats.Update(Chat);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ChatExists(id))
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

        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat Chat)
        {
            await _unitOfWork.Chats.Insert(Chat);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetChat", new { id = Chat.Id }, Chat);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var Chat = await _unitOfWork.Chats.Get(q => q.Id == id);
            if (Chat == null)
            {
                return NotFound();
            }

            await _unitOfWork.Chats.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ChatExists(int id)
        {
            var Chat = await _unitOfWork.Chats.Get(q => q.Id == id);
            return Chat != null;
        }
    }
}