using eshop.MessageBus;

namespace eshop.OrderAPI.Messages
{
    public class PaymentVO: BaseMessage
    {
        public long OrderId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMothYear { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Email { get; set; }
    }
}
