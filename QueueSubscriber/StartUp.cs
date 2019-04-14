using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueSubscriber.Interface.Contracts;
using QueueSubscriber.Service.Services;
using System.IO;

namespace QueueSubscriber
{
    public class StartUp
    {
        public StartUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

        }
        public IConfiguration Configuration { get; }
        internal IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);            
            services.AddSingleton<IConsumerMessageService, RabbitConsumerService>();
            services.AddTransient<IValidationService, ValidationService>();

            return services;
        }
    }
}
