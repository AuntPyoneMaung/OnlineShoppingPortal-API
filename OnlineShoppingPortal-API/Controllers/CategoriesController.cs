using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingPortal_API.Models;
using OnlineShoppingPortal_API.Repositories;

namespace OnlineShoppingPortal_API.Controllers
{
    //[EnableCors("ShoppingOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        //[Authorize]
        [HttpGet]
        [Route("getAllCategory")]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                return Ok(await categoryRepository.GetCategories());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                // can input own error msg
                // return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // GET: api/Categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            try
            {
                var result = await categoryRepository.GetCategory(categoryId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest();

                var createdCategory = await categoryRepository.AddCategory(category);
                return CreatedAtAction(nameof(GetCategory),
                 new { id = createdCategory.CategoryId }, createdCategory);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Category>> DeleteCategory(int categoryId)
        {
            try
            {
                var toDelete = categoryRepository.GetCategory(categoryId);
                if (toDelete == null)
                {
                    return NotFound($"Employee with Id = {categoryId} not found");
                }
                return await categoryRepository.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        //// PUT: api/Categories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.CategoryId)
        //    {
        //        return BadRequest();
        //    }

        //    categoryRepository.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await categoryRepository.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.CategoryId == id);
        //}
    }
}
