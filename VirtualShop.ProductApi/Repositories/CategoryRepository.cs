using APICatalog.Repositories;
using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDBContext _context;
        private UnityOfWork _unityOfWork;
      

        public CategoryRepository(AppDBContext context, UnityOfWork unityOfWork)
        {
            _context = context;
            _unityOfWork = unityOfWork;
        }

        public async Task<IQueryable<Category>> GetAllCategoriesAsync()
        {
            return (IQueryable<Category>)await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<Category> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = _context.Products.Where(p => p.CategoryId == categoryId);
            return (IQueryable<Category>)products;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _unityOfWork.CommitAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _unityOfWork.CommitAsync();
            return category;
        }
        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            _context.Categories.Remove(category);
            await _unityOfWork.CommitAsync();
            return category;
        }
    }
}
