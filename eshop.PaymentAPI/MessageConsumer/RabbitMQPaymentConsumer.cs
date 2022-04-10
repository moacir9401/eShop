using eshop.PaymentAPI.Messages;
using eshop.PaymentAPI.RabbitMQSender;
using eshop.PaymentProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace eshop.PaymentoAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {

        private readonly IConnection _connection;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;
        private IModel _channel;
        private IProcessPayment _processPayment;

        public RabbitMQPaymentConsumer(IProcessPayment processPayment, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _processPayment = processPayment;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "orderPaymentProcessQueue", false, false, false, arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());

                PaymentMessage vo = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(vo).GetAwaiter().GetResult();

                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume("orderPaymentProcessQueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage vo)
        {

            var result = _processPayment.PaymentProcessor();

            UpdatePaymentResultMessage paymentResult = new()
            {
                Status = result,
                OrderId = vo.OrderId,
                Email = vo.Email
            };

            try
            {
                _rabbitMQMessageSender.SendMessage(paymentResult, "orderPaymentResultQueue");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

