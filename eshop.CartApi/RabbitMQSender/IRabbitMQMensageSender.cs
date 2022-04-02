using eshop.MessageBus;
using System.Threading.Tasks;

namespace eshop.CartApi.RabbitMQSender
{
    public interface IRabbitMQMensageSender
    {
        void SendMenssage(BaseMessage baseMessage, string queueName);
    }
}
