using Person_API.Events;
using Person_API.Interfaces;
using Person_API.Model;
using RabbitMQ.Client;
using System.Text.Json;

namespace Person_API.Integrations
{
    public class NewPersonAddedNotification : INewPersonAddedNotification
    {
        private readonly ILogger<NewPersonAddedNotification> _logger;
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;
        private string queueName = "Person.New";

        public NewPersonAddedNotification(ILogger<NewPersonAddedNotification> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            InitMessageBroker();
        }

        private void InitMessageBroker()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetValue<string>("RabbitMqHost")
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public Task<bool> NewPersonAdded(Person person, string Id)
        {
            var message = new NewPersonAdded { Id = Id, Person = person };

            var messageBytes = JsonSerializer.SerializeToUtf8Bytes(message);

            _channel.BasicPublish("", routingKey: queueName, basicProperties: null,body: messageBytes);

            _logger.LogInformation($"Published NewPersonAdded Message - Body {message}");

            return Task.FromResult(true);
        }


    }
}
