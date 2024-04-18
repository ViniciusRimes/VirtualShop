using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(c=>c.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
            return products;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return product;
        }
        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            return product;
        }
    }
}
