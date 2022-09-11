using System;
using MBroker.DataProcessor.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MBroker.DataProcessor {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config.AddConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build());
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.RegisterConfigurationServices(hostContext);
                    services.RegisterBusinessServices();
                    services.RegisterRepositoryServices();
                    services.RegisterQueueServices(hostContext);
                    services.AddHostedService<Worker>();
                });
    }
}
