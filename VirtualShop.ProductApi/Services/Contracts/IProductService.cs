using VirtualShop.ProductApi.DTOs;

namespace VirtualShop.ProductApi.Services.Contracts
{
    public interface IProductService
    {
        Task <List<ProductDTO>> GetAllProductsAsync();
        Task <ProductDTO> GetProductByIdAsync(int id);
        Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
        Task CreateProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int id);
    }
}
