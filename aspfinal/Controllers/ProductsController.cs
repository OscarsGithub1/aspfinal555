using aspfinal.Services;
using aspfinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                ProductModel = await _productService.GetProduct()
            };

            return View(viewModel);
        }

        [Authorize (Roles = "Admin, Product Manager")]
        public IActionResult Product()
        {
            return View();
        }
    }
}
