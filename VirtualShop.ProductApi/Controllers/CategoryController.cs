using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services.Contracts;

namespace VirtualShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/categories")]
        public async Task<ActionResult<IQueryable<CategoryDTO>>> GetAllCategoriesAsync() 
        {
            var categoriesDTO = await _categoryService.GetAllCategoriesAsync();
            if(categoriesDTO == null)
            {
                return NotFound("Categories not found!");
            }
            return Ok(categoriesDTO);
        }
        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryByIdAsync(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryByIdAsync(id);
            if(categoryDTO == null)
            {
                return NotFound("Category not found!");
            }
            return Ok(categoryDTO);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync([FromBody]CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid data!");
            }
            await _categoryService.CreateCategoryAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategoryById", new { id = categoryDTO.Id }, categoryDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null && id != categoryDTO!.Id)
            {
                return BadRequest("Invalid data!");
            }
            await _categoryService.UpdateCategoryAsync(categoryDTO);
            return Ok(categoryDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryByIdAsync(id);
            if(categoryDTO == null)
            {
                return NotFound("Category not found!");
            }
            await _categoryService.DeleteCategoryAsync(id);
            return Ok(categoryDTO);
        }
    }
}
