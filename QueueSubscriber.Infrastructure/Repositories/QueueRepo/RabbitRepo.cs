using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSubscriber.Infrastructure.Repositories.QueueRepo
{
    public class RabbitRepo: IQueueSubscriberRepo   
    {
        private readonly IConfiguration _configuration;

        public RabbitRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task RunAsync(CancellationToken cancellationToken)
        {
            var channel = CreateChannel();
            channel.QueueDeclare(_configuration.GetSection("AppSettings:QueueName").Value, true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            channel.BasicConsume(queue: _configuration.GetSection("AppSettings:QueueName").Value,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return Task.CompletedTask;
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory() { HostName = _configuration.GetSection("AppSettings:QueueHostName").Value };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return channel;
        }        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping..");
            return Task.CompletedTask;
        }
    }
}
