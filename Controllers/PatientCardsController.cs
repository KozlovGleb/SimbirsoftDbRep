using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimbirsoftDbRep.Common.Swagger;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Database.Domain;

namespace SimbirsoftDbRep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Cards)]
    public class PatientCardsController : ControllerBase
    {
        private readonly HospitalContext _context;

        public PatientCardsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: api/PatientCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientCard>>> GetPatientCards()
        {
            return await _context.PatientCards.ToListAsync();
        }

        // GET: api/PatientCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientCard>> GetPatientCard(long id)
        {
            var patientCard = await _context.PatientCards.FindAsync(id);

            if (patientCard == null)
            {
                return NotFound();
            }

            return patientCard;
        }

        // PUT: api/PatientCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientCard(long id, PatientCard patientCard)
        {
            if (id != patientCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientCardExists(id))
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

        // POST: api/PatientCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientCard>> PostPatientCard(PatientCard patientCard)
        {
            _context.PatientCards.Add(patientCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientCard", new { id = patientCard.Id }, patientCard);
        }

        // DELETE: api/PatientCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientCard>> DeletePatientCard(long id)
        {
            var patientCard = await _context.PatientCards.FindAsync(id);
            if (patientCard == null)
            {
                return NotFound();
            }

            _context.PatientCards.Remove(patientCard);
            await _context.SaveChangesAsync();

            return patientCard;
        }

        private bool PatientCardExists(long id)
        {
            return _context.PatientCards.Any(e => e.Id == id);
        }
    }
}
