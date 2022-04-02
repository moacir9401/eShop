using eshop.CartApi.Messages;
using eshop.MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace eshop.CartApi.RabbitMQSender
{
    public class RabbitMQSender : IRabbitMQMensageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQSender()
        {
            _hostName = "localhost";
            _userName = "guest";
            _password = "guest";
        }

        public void SendMenssage(BaseMessage message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password,
            };

            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: _hostName, false, false, false, arguments: null);

            byte[] body = GetMessageAsByteArray(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

            throw new NotImplementedException();
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

           var json = JsonSerializer.Serialize<CheckoutHeaderVO>((CheckoutHeaderVO)message, options);

            var body = Encoding.UTF8.GetBytes(json);

            return body;
        }
    }
}
