using eShop.Order.Model.Base;

namespace eshop.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);

    }
}
