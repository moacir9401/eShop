using eShop.ProductAPIs.Model;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductAPI.Model.Context
{
    public class MySqlContext:DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options):base(options) { } 
        public DbSet<Product> products { get; set; }

    }
}
