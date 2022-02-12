using eShop.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.CartApi.Model
{
    [Table("product")]
    public class CartHeader: BaseEntity
    {
        [Column("User_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}
