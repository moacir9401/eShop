using eshop.CartApi.Data.ValueObjects;

namespace eshop.CartApi.Repository
{
    public interface ICartRepository
    {
        Task<CartVO> FindCartByUserId(string userId);
        Task<CartVO> SaveOrUpdateCart(CartVO cart);
        Task<bool> RemoveFromCart(long cartDetailsId);
        Task<bool> ApplyCoupon(string unserId,string couponCode);
        Task<bool> RemoveCoupon(string unserId);
        Task<bool> ClearCart(string unserId);

    }
}
