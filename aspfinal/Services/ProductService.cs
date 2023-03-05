using aspfinal.Context;
using aspfinal.Models;
using aspfinal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspfinal.Services
{
    
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductModel> GetProduct()
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync();

            return new ProductModel
            {
           
                Name = productEntity!.Name,
                Category = productEntity.Category,
                Price = productEntity.Price
            };
        }
    }
  
}
