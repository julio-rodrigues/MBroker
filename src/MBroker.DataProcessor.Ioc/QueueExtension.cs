using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MassTransit;
using MBroker.DataProcessor.Domain.Utils;
using MBroker.DataProcessor.Services.Consumers;
using Microsoft.Extensions.Logging;

namespace MBroker.DataProcessor.Ioc {
    public static class QueueExtension {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services, HostBuilderContext context) {
            var queueSettings = new QueueSettings();
            context.Configuration.GetSection("QueueSettings").Bind(queueSettings);

            services.AddMassTransit(c =>
            {
                c.AddConsumer<TesteConsumer>();
            });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(queueSettings.HostName, queueSettings.VirtualHost, h => {
                    h.Username(queueSettings.UserName);
                    h.Password(queueSettings.Password);
                });
                //cfg.SetLoggerFactory(provider.GetService<ILoggerFactory>());

                cfg.UseRawJsonDeserializer();

            }));

            return services;
        }
    }
}
