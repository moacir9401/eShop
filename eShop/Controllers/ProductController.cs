using eShop.Models;
using eShop.Services.IServices;
using eShop.Utils;
using Microsoft.AspNetCore.Authentication;
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

         [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAllProducts(token);
            return View(products);
        }

        [Authorize]
        [HttpGet("Create")]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> ProductCreate([FromForm]ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProduct(model,token);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        [Authorize]
        [HttpGet("Update")]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id,token);
            if(model != null) return View(model);

            return View(NotFound());
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> ProductUpdate([FromForm] ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct(model,token);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        [Authorize]
        [HttpGet("Delete")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id,token);
            if (model != null) return View(model);

            return View(NotFound());
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("Delete")]
        public async Task<IActionResult> ProductDelete([FromForm] ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductById(model.Id,token);
            if (response) return RedirectToAction(
                     nameof(ProductIndex));

            return View(model);
        }

    }
}