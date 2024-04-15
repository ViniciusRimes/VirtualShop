using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IQueryable<Category>> GetAllCategoriesAsync();
        IQueryable<Category> GetProductsByCategoryIdAsync(int categoryId);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
