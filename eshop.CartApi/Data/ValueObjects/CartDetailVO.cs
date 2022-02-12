using eShop.CartAPI.Data.ValueObjects;
using eShop.CartAPI.Model.Base;

namespace eshop.CartApi.Data.ValueObjects
{
    public class CartDetailVO : BaseEntity
    {
        public long CartHeaderId { get; set; }
        public virtual CartHeaderVO CartHeader { get; set; }
        public long ProductId { get; set; }
        public virtual ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
