using eShop.CartAPI.Model.Base;

namespace eshop.CartApi.Data.ValueObjects
{

    public class CartHeaderVO 
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
