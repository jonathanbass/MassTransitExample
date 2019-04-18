using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;

namespace Subscriber
{
    internal class SomethingHappenedConsumer : IConsumer<ISomethingHappened>
    {
        public async Task Consume(ConsumeContext<ISomethingHappened> context)
        {
            var observation = $"Received SomethingHappenedMessage. Time: {context.Message.Time:dd-MMM-yyyy}, Observation: {context.Message.Observation}";
            await Console.Out.WriteLineAsync(observation);
        }
    }
}
