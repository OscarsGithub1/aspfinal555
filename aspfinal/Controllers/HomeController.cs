using aspfinal.Context;
using aspfinal.Models.Identity;
using aspfinal.Services;
using aspfinal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityContext _context;
        private readonly ProductService _productService;

        public HomeController(IdentityContext context, ProductService productService)
        {
            _context = context;
            _productService = productService;
        }

      //  public async Task<IActionResult> Index()
        //{
          //  var test = new TEstEntity();
            //var result = _context.Add(test);
           // var savettttt = await _context.SaveChangesAsync();

            
            //return View();
     //   }
        public async Task<IActionResult> IndexAsync()
        {
            var viewModel = new IndexViewModel
            {
                ProductModel = await _productService.GetProduct()
            };

            return View(viewModel);
        }
    }
}
