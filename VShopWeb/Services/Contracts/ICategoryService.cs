using VShopWeb.Models;

namespace VShopWeb.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        //Task<CategoryViewModel> GetAllPCategorieByIdAsync(int id);
        //Task<CategoryViewModel> CreateCategorieAsync(CategoryViewModel category);
        //Task<CategoryViewModel> UpdateCategorieAsync(CategoryViewModel category);
        //Task<bool> DeleteCategorieAsync(int id);
    }
}
