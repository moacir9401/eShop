using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Order.Model.Base
{
    [Table("order_detail")]
    public class OrderDetail : BaseEntity
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }


        public long CartHeaderId { get; set; }
        public virtual CartHeaderVO? CartHeader { get; set; }
        public long ProductId { get; set; }
        public virtual ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
