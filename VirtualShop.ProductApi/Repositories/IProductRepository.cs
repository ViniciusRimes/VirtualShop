using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(int id);
    }
}
