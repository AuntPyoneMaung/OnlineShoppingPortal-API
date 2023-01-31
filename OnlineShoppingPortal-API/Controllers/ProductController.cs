using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Models;
using System.Collections;

namespace ProductCrudAPI.Controllers
{
    //[EnableCors("ShoppingOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //RepositoryInterface object
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            return await _context.Products.Include(b => b.BrandProducts).ThenInclude(c => c.Brand).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
                if (product == null)
                    return NotFound($"with given {id} product not found");
                //return Ok(product); // single object
                List<Product> plist = new List<Product>();
                plist.Add(product);
                return Ok(plist);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error while fetching records");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return Ok(); // ok with data 

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error while creating new product record");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product productData)
        {
            try
            {
                if (productData == null || productData.ProductId == 0)
                    return BadRequest();

                var product = await _context.Products.FindAsync(productData.ProductId);
                if (product == null)
                    return NotFound($"with given {productData.ProductId} product not found");
                product.ProductName = productData.ProductName;
                product.ProductDescription = productData.ProductDescription;
                product.ProductModel = productData.ProductModel;
                product.ProductPrice = productData.ProductPrice;
                
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error while updating product record");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                    return NotFound($"with given {id} product not found");
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error while deleting product record");
            }

        }



    }
}