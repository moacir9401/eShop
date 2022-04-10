
using eShop.Email.Model.Base;
using eShop.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace eshop.Email.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<MySqlContext> _context; 

        public OrderRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context; 
        }
         

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            //await using var _db = new MySqlContext(_context);
            //var header = await _db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);

            //if(header != null)
            //{
            //    header.PaymentStatus = status;
            //    await _db.SaveChangesAsync();
            //}
        } 
    }
}
