using eShop.Models;
using eShop.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet("/")]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> ProductCreate([FromForm]ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        [HttpGet("Update")]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var model = await _productService.FindProductById(id);
            if(model != null) return View(model);

            return View(NotFound());
        }

        [HttpPost("Update")]
        public async Task<IActionResult> ProductUpdate([FromForm] ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _productService.FindProductById(id);
            if (model != null) return View(model);

            return View(NotFound());
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> ProductDelete([FromForm] ProductModel model)
        {

            var response = await _productService.DeleteProductById(model.Id);
            if (response) return RedirectToAction(
                     nameof(ProductIndex));

            return View(model);
        }

    }
}