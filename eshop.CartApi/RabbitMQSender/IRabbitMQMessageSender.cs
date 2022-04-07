using eshop.MessageBus;
using System.Threading.Tasks;

namespace eshop.CartApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
