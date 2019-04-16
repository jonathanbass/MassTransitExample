using MassTransit;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "test_queue", e =>
                {
                    e.Consumer<SomethingHappenedConsumer>();
                });
            });

            busControl.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            busControl.Stop();
        }
    }
}
