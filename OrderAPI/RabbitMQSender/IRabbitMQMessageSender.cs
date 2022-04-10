using eshop.MessageBus;
using System.Threading.Tasks;

namespace eshop.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
