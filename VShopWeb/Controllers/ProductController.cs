using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShopWeb.Models;
using VShopWeb.Services.Contracts;

namespace VShopWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAllProductsAsync();
            if(result == null)
            {
                return View("Error");
            }
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> CreateProduct()
        {
            ViewBag.Id = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _productService.CreateProductAsync(productViewModel);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "Name");
                }
            }
            return View(productViewModel);
        }
    }
}
