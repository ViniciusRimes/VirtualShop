using System.Text;
using System.Text.Json;
using VShopWeb.Models;
using VShopWeb.Services.Contracts;

namespace VShopWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;
        private const string apiEndpoint = "/api/products";

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using(var response = await client.GetAsync(apiEndpoint))
            {
                if(response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _serializerOptions);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsByCategoryAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _serializerOptions);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ProductViewModel> GetAllProductsByIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if(response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _serializerOptions);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            StringContent content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _serializerOptions);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ProductViewModel> UpdateProductAsync(ProductViewModel product)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            ProductViewModel productUpdated = new ProductViewModel();
            using (var response = await client.PutAsJsonAsync(apiEndpoint, product))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _serializerOptions);
                }
                else
                {
                    return null;
                }
            }
            return productUpdated;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            
            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
