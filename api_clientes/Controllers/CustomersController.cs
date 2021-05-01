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
    [EnableCors]
    public class CustomersController : ControllerBase
    {
        private readonly ClienteContext _context;

        public CustomersController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        //[Authorize(Roles = "admin,vendedor")]

        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "admin,vendedor")]
        public async Task<ActionResult<Customers>> GetCustomers(int id)
        {
            var customers = await _context.customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            if (id != customers.id)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        //[AllowAnonymous]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            _context.customers.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomers", new { id = customers.id }, customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var customers = await _context.customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomersExists(int id)
        {
            return _context.customers.Any(e => e.id == id);
        }
    }
}
