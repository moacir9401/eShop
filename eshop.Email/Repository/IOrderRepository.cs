using eShop.Email.Model.Base;

namespace eshop.Email.Repository
{
    public interface IOrderRepository
    { 
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);

    }
}
