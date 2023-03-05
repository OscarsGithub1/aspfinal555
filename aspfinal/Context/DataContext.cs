using aspfinal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspfinal.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
