using MassTransit;
using System;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                //sbc.ReceiveEndpoint(host, "test_queue", ep =>
                //{
                //    ep.Handler<SomethingHappenedMessage>(context =>
                //    {
                //        return Console.Out.WriteLineAsync($"Received: {context.Message.Observation}, Time: {context.Message.Time.ToString("dd-MMM-yyyy")}");
                //    });
                //});
            });

            bus.Start();

            var message = new SomethingHappenedMessage { Time = DateTime.Now, Observation = Guid.NewGuid().ToString() };
            bus.Publish(message);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
