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
    public class ProductsController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ProductsController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        //[AllowAnonymous]

        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //[AllowAnonymous]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]

        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]

        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [EnableCors("AnotherPolicy")]
        //[Authorize(Roles = "admin,vendedor")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.id == id);
        }
    }
}
