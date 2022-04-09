using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Order.Model.Base
{
    [Table("order_detail")]
    public class OrderDetail : BaseEntity
    {
        [ForeignKey("orderHeaderId")]
        public long OrderHeaderId { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        
        [Column("productId")] 
        public long ProductId { get; set; }

        [Column("count")]
        public int Count { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
    }
}
