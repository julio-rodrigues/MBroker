using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MBroker.DataProcessor.Domain.Messages;
using MBroker.DataProcessor.Domain.Utils;
using MBroker.DataProcessor.Services.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MBroker.DataProcessor {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;
        private readonly QueueSettings _queueSettings;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger, IBusControl busControl, QueueSettings queueSettings) {
            _logger = logger;
            _busControl = busControl;
            _serviceProvider = serviceProvider;
            _queueSettings = queueSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

            await _busControl.StartAsync(stoppingToken);

            try {

                _logger.LogInformation("DataProcessor started!");

                var testeHandler = _busControl.ConnectReceiveEndpoint(_queueSettings.QueueName,
                    x => { x.Consumer<TesteConsumer>(_serviceProvider); });

                await testeHandler.Ready;

            }
            catch (Exception ex) {
                _logger.LogError("DataProcessor cannot be started.", ex);
            }
            finally {
                await _busControl.StopAsync(stoppingToken);
            }
        }
    }
}
