using Person_Processor.Events;
using Person_Processor.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Person_Processor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPersonSocialMediaLogic _personSocialMediaLogic;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private string queueName = "Person.New";
        private EventingBasicConsumer _consumer;

        public Worker(IConfiguration config,ILogger<Worker> logger, IPersonSocialMediaLogic  personSocialMediaLogic)
        {
            _logger = logger;
            _personSocialMediaLogic = personSocialMediaLogic;

            var factory = new ConnectionFactory
            {
                HostName = config.GetValue<string>("RabbitMqHost")
            };
            try
            {
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                for (var i = 0; i < 5; i++)
                {
                    if (_connection != null)
                        continue;
                    Thread.Sleep(3000);
                    try { _connection = factory.CreateConnection(); } catch { }
                }
                if (_connection == null) throw;
            }

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += ProcessNewPersonAdded;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           _logger.LogInformation("Message Received at: {time}", DateTimeOffset.Now);
            while (!stoppingToken.IsCancellationRequested)
            {
                _channel.BasicConsume(queue: queueName, autoAck: true, consumer: _consumer);
            }

            return Task.CompletedTask;
        }

        private async void ProcessNewPersonAdded(object sender, BasicDeliverEventArgs eventArgs)
        {
            try
            {
                var personInfo = JsonSerializer.Deserialize<NewPersonAdded>(eventArgs.Body.ToArray());

                _logger.LogInformation($"NewPerson Received for processing, New Person : {personInfo}");

                await _personSocialMediaLogic.AddSocialMediaData(personInfo.Person, personInfo.Id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error in ProcessNewPersonAdded, Exception : {ex}");
            }           
            
        }
    }
}