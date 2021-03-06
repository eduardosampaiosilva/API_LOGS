using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_LOGS.Model;
using Newtonsoft.Json;

namespace API_LOGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogEmailsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LogEmailsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/LogEmails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEmail>>> GetLogEmails()
        {
            return await _context.LogEmails.ToListAsync();
        }

        // GET: api/LogEmails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogEmail>> GetLogEmail(string id)
        {
            var logEmail = await _context.LogEmails.FindAsync(id);

            if (logEmail == null)
            {
                return NotFound();
            }

            return logEmail;
        }

        // PUT: api/LogEmails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogEmail(string id, LogEmail logEmail)
        {
            if (id != logEmail.Id)
            {
                return BadRequest();
            }

            _context.Entry(logEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogEmailExists(id))
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

        [HttpPost]
        public async Task<ActionResult<LogEmail>> PostLogEmail(LogEmailSentRecords logEmail)
        {
            var logEmailFirst = logEmail.Records.FirstOrDefault();
            var model = new LogEmail();
            var message = JsonConvert.DeserializeObject<LogEmailMessage>(logEmailFirst.Sns.Message);

            model.Id = logEmailFirst.Sns.MessageId;
            model.EventType = message.EventType;
            model.IdExame = message.Mail.Tags.IdExame;
            model.IdEmpresa = message.Mail.Tags.IdEmpresa;

            _context.LogEmails.Add(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogEmailExists(model.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogEmail", new { id = model.Id }, model);
        }



        // DELETE: api/LogEmails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogEmail>> DeleteLogEmail(string id)
        {
            var logEmail = await _context.LogEmails.FindAsync(id);
            if (logEmail == null)
            {
                return NotFound();
            }

            _context.LogEmails.Remove(logEmail);
            await _context.SaveChangesAsync();

            return logEmail;
        }

        private bool LogEmailExists(string id)
        {
            return _context.LogEmails.Any(e => e.Id == id);
        }
    }
}
