using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBroker.DataProcessor.Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MBroker.DataProcessor.Ioc {
    public static class ConfigurationServiceExtension {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection service, HostBuilderContext context) {
            //var connectionStrings = new ConnectionStrings();
            var queueSettings = new QueueSettings();

            //context.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);
            context.Configuration.GetSection("QueueSettings").Bind(queueSettings);

            //service.AddSingleton(connectionStrings);
            service.AddSingleton(queueSettings);

            return service;
        }
    }
}
