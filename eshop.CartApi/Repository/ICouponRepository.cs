using eshop.CartApi.Data.ValueObjects;

namespace eshop.CartApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string couponCode, string token);
    }
}
