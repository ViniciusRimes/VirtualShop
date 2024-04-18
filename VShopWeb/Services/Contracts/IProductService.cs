using VShopWeb.Models;

namespace VShopWeb.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<IEnumerable<ProductViewModel>> GetAllProductsByCategoryAsync(int id);
        Task<ProductViewModel> GetAllProductsByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(ProductViewModel product);
        Task<ProductViewModel> UpdateProductAsync(ProductViewModel product);
        Task<bool> DeleteProductAsync(int id);
    }
}
