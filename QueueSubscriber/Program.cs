using Microsoft.Extensions.DependencyInjection;
using QueueSubscriber.Interface.Contracts;
using System;

namespace QueueSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceHost();

            serviceProvider.GetService<IConsumerMessageService>().Run();
        }

        private static IServiceProvider BuildServiceHost()
        {
            var services = new StartUp().ConfigureServices(new ServiceCollection());

            return services.BuildServiceProvider();
        }
    }
}
