using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public BrandProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BrandProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandProduct>>> GetBrandProducts()
        {
            return await _context.BrandProducts.Include(p => p.Product).Include(b => b.Brand).ToListAsync();
        }

        // GET: api/BrandProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandProduct>> GetBrandProduct(int id)
        {
            var brandProduct = await _context.BrandProducts.FindAsync(id);

            if (brandProduct == null)
            {
                return NotFound();
            }

            return brandProduct;
        }

        // PUT: api/BrandProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandProduct(int id, BrandProduct brandProduct)
        {
            if (id != brandProduct.BrandId)
            {
                return BadRequest();
            }

            _context.Entry(brandProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandProductExists(id))
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

        // POST: api/BrandProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BrandProduct>> PostBrandProduct(BrandProduct brandProduct)
        {
            _context.BrandProducts.Add(brandProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BrandProductExists(brandProduct.BrandId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBrandProduct", new { id = brandProduct.BrandId }, brandProduct);
        }

        // DELETE: api/BrandProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandProduct(int id)
        {
            var brandProduct = await _context.BrandProducts.FindAsync(id);
            if (brandProduct == null)
            {
                return NotFound();
            }

            _context.BrandProducts.Remove(brandProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandProductExists(int id)
        {
            return _context.BrandProducts.Any(e => e.BrandId == id);
        }
    }
}
