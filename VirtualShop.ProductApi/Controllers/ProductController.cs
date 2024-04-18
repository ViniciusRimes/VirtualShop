using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Services;
using VirtualShop.ProductApi.Services.Contracts;

namespace VirtualShop.ProductApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("products")]
        public async Task<ActionResult<IQueryable<ProductDTO>>> GetAllProductsAsync( )
        {
            var productsDTO = await _productService.GetAllProductsAsync();
            if (productsDTO == null)
            {
                return NotFound("Products not found!");
            }
            return Ok(productsDTO);
        }
        [HttpGet("products/{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var productDTO = await _productService.GetProductByIdAsync(id);
            if (productDTO == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(productDTO);
        }
        [HttpGet("category/{id:int}")]
        public async Task<ActionResult<IQueryable<ProductDTO>>> GetAllProductsByCategoryAsync(int id)
        {
            var productsDTO = await _productService.GetProductsByCategoryIdAsync(id);
            if (productsDTO == null)
            {
                return NotFound("Products not found!");
            }
            return Ok(productsDTO);
        }
        [HttpPost("products")]
        public async Task<ActionResult> CreateProductAsync([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("Invalid data!");
            }
            await _productService.CreateProductAsync(productDTO);
            return new CreatedAtRouteResult("GetProductById", new { id = productDTO.Id }, productDTO);
        }
        [HttpPut("products/{id:int}")]
        public async Task<ActionResult> UpdateProductAsync(int id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null && id != productDTO!.Id)
            {
                return BadRequest("Invalid data!");
            }
            await _productService.UpdateProductAsync(productDTO);
            return Ok(productDTO);
        }
        [HttpDelete("products/{id:int}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var productDTO = await _productService.GetProductByIdAsync(id);
            if (productDTO == null)
            {
                return NotFound("Product not found!");
            }
            await _productService.DeleteProductAsync(id);
            return Ok(productDTO);
        }
    }
}
