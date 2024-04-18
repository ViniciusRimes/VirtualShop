using System.Text.Json;
using VShopWeb.Models;
using VShopWeb.Services.Contracts;

namespace VShopWeb.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;
        private const string apiEndpoint = "/api/categories";

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _serializerOptions);

                }
                else
                {
                    return null!;
                }
            }
        }

        //public Task<CategoryViewModel> GetAllPCategorieByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public Task<CategoryViewModel> CreateCategorieAsync(CategoryViewModel category)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<CategoryViewModel> UpdateCategorieAsync(CategoryViewModel category)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> DeleteCategorieAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
