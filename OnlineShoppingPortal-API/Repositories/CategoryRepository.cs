using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Models;
using System;

namespace OnlineShoppingPortal_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // show and add

        private readonly DataContext dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // ienum for data from in-memory collection like array, list
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dataContext.Categories.Include(c => c.Segment).ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            return await dataContext.Categories.FirstOrDefaultAsync(e => e.CategoryId == categoryId);
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await dataContext.Categories.AddAsync(category);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> DeleteCategory(int categoryId)
        {
            var result = await dataContext.Categories.FirstOrDefaultAsync(emp => emp.CategoryId == categoryId);
            if (result != null)
            {
                dataContext.Categories.Remove(result);
                await dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


    }
}
