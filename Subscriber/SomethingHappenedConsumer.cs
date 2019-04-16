using Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Subscriber
{
    class SomethingHappenedConsumer : IConsumer
    {
        public async Task Consume(ConsumeContext<SomethingHappened> context)
        {
            var ghfhgfhg = 1;
            await Console.Out.WriteLineAsync($"Date: {context.Message.Time.ToString("dd-MMM-yyyy")}, Obeservation: {context.Message.Observation}");
        }
    }
}
