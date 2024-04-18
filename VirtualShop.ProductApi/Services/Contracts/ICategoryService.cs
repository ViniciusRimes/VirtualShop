using VirtualShop.ProductApi.DTOs;

namespace VirtualShop.ProductApi.Services.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CategoryDTO categoryDTO);
        Task UpdateCategoryAsync(CategoryDTO categoryDTO);
        Task DeleteCategoryAsync(int categoryId);
    }
}
