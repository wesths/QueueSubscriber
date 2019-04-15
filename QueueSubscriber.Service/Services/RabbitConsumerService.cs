using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using QueueSubscriber.Interface.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QueueSubscriber.Service.Services
{
    public class RabbitConsumerService : IConsumerMessageService
    {        
        private readonly IConfiguration _configuration;
        private readonly IValidationService _validationService;
        private readonly IModel channel;

        public RabbitConsumerService(IConfiguration configuration,
            IValidationService validationService)
        {
            _configuration = configuration;
            _validationService = validationService;
            channel = CreateChannel();
        }

        public void Run()
        {            
            channel.QueueDeclare(_configuration.GetSection("AppSettings:QueueName").Value, true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(_validationService.ValidateMessage(message));                
            };
            channel.BasicConsume(queue: _configuration.GetSection("AppSettings:QueueName").Value,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("I am listening for any messages on Rabbit...");
            Console.ReadLine();
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("AppSettings:QueueHostName").Value
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return channel;
        }

    }
}
