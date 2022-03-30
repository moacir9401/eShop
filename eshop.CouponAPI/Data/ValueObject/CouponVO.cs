namespace eshop.CouponAPI.Data.ValueObject
{
    public class CouponVO
    { 
        public long Id { get; set; }
        public string? CoupomCode { get; set; } 
        public decimal DiscountAmount { get; set; }
    }
}
