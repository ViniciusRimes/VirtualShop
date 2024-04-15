using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories;
using VirtualShop.ProductApi.Services.Contracts;

namespace VirtualShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnityOfWork unityOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductDTO>>(products);   
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products =  await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task CreateProductAsync(ProductDTO productDTO)
        {
            var newProduct = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateProductAsync(newProduct);
            await _unityOfWork.CommitAsync();
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var newProduct = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateProductAsync(newProduct);
            await _unityOfWork.CommitAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            await _unityOfWork.CommitAsync();
        }
    }
}
