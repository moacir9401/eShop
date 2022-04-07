using eShop.Order.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace eShop.Order.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { } 
        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<OrderHeader> Headers { get; set; }

    }
}
