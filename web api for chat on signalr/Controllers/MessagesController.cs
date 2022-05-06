using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using web_api_for_chat_on_signalr.Models;

namespace web_api_for_chat_on_signalr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MessagesController(ApplicationContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages =  _context.Messages.ToListAsync();
            return Ok(messages);
        }

      

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostMessage", new { id = message.MessageId }, message);
        }

 
  

      

    }
}
