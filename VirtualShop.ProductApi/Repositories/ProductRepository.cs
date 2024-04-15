using APICatalog.Repositories;
using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext _context;
        private UnityOfWork _unityOfWork;

        public ProductRepository(AppDBContext context, UnityOfWork unityOfWork)
        { 
            _context = context;
            _unityOfWork = unityOfWork;
        }
        public async Task<IQueryable<Product>> GetAllProductsAsync()
        {
            return (IQueryable<Product>)await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _unityOfWork.CommitAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _unityOfWork.CommitAsync();
            return product;
        }
        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            await _unityOfWork.CommitAsync();
            return product;
        }
    }
}
