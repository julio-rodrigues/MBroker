using System;
using System.Threading.Tasks;
using MassTransit;
using MBroker.DataProcessor.Domain.Messages;

namespace MBroker.DataProcessor.Services.Consumers {
    public class TesteConsumer : IConsumer<TesteMessage> {
        public async Task Consume(ConsumeContext<TesteMessage> context) {

            try {

                Console.WriteLine("Mensagem: " + context.Message);

            } catch (Exception ex) {

            }

        }
    }
}