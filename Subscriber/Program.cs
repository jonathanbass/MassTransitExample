using System;
using MassTransit;

namespace Subscriber
{
    internal class Program
    {
        internal static void Main()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Consumer<SomethingHappenedConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
