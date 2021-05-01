using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_clientes.Contexts;
using api_clientes.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace api_clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AnotherPolicy")]

    public class NaturalPersonsController : ControllerBase
    {
        private readonly ClienteContext _context;

        public NaturalPersonsController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/NaturalPersons
        [HttpGet]
        [EnableCors("AnotherPolicy")]
        [Authorize(Roles = "admin,vendedor")]

        public async Task<ActionResult<IEnumerable<NaturalPerson>>> Getnatural_person()
        {
            return await _context.natural_person.ToListAsync();
        }

        // GET: api/NaturalPersons/5
        [HttpGet("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]

        public async Task<ActionResult<NaturalPerson>> GetNaturalPerson(int id)
        {
            var naturalPerson = await _context.natural_person.FindAsync(id);

            if (naturalPerson == null)
            {
                return NotFound();
            }

            return naturalPerson;
        }

        // PUT: api/NaturalPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin")]

        public async Task<IActionResult> PutNaturalPerson(int id, NaturalPerson naturalPerson)
        {
            if (id != naturalPerson.id)
            {
                return BadRequest();
            }

            _context.Entry(naturalPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturalPersonExists(id))
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

        // POST: api/NaturalPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        //[AllowAnonymous]

        public async Task<ActionResult<NaturalPerson>> PostNaturalPerson(NaturalPerson naturalPerson)
        {
            _context.natural_person.Add(naturalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaturalPerson", new { id = naturalPerson.id }, naturalPerson);
        }

        // DELETE: api/NaturalPersons/5
        [HttpDelete("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteNaturalPerson(int id)
        {
            var naturalPerson = await _context.natural_person.FindAsync(id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            _context.natural_person.Remove(naturalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaturalPersonExists(int id)
        {
            return _context.natural_person.Any(e => e.id == id);
        }
    }
}
