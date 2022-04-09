using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Order.Model.Base
{
    [Table("order_header")]
    public class OrderHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
        [Column("Purchase_amount")]
        public decimal PurchaseAmount { get; set; }
        [Column("Discount_total")]
        public decimal DiscountTotal { get; set; }
        [Column("First_name")]
        public string FirstName { get; set; }
        [Column("Last_name")]
        public string LastName { get; set; }
        [Column("purchase_date")]
        public DateTime DateTime { get; set; }
        [Column("Order_ime")]
        public DateTime OrderTime { get; set; }
        [Column("phone_number")]
        public string Phone { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("card_number")]
        public string CardNumber { get; set; }
        [Column("cvv")]
        public string CVV { get; set; }
        [Column("expiry _moth_year")]
        public string ExpiryMothYear { get; set; }
        [Column("total_itens")]
        public int CartTotalItens { get; set; } 
        public IEnumerable<OrderDetail>? CartDetails { get; set; }
        [Column("payment_status")]
        public bool PaymentStatus { get; set; }
    }
}
