using eShop.Models;

namespace eShop.Services.Iservices
{
    public interface ICouponServices
    {
        Task<CouponViewModel> GetCoupon(string code, string token); 

    }
}
