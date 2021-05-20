using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Pessoas.Service.Queues
{
    public class ServiceBus : IServiceBus
    {
        private readonly ConnectionFactory factory;
        public ServiceBus(string hostName)
        {
            factory = new ConnectionFactory() { HostName = hostName };
        }

        public void SendQueue<Entity>(QueueRequest<Entity> queueRequest)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueRequest.QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(queueRequest.Value);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: queueRequest.Exchange,
                                     routingKey: queueRequest.QueueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
