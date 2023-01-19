using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> DeleteCategory(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int categoryId);
    }
}