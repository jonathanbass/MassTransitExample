using System;
using MassTransit;

namespace Publisher
{
    internal class Program
    {
        internal static void Main()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();

            Console.Write("Please enter the number of messages to send: ");
            var messageCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < messageCount; i++)
            {
                var message = new SomethingHappenedMessage { Time = DateTime.Now, Observation = Guid.NewGuid().ToString() };
                bus.Publish(message);
                Console.WriteLine($"Published SomethingHappenedMessage. Time: {message.Time}, Observation: {message.Observation}");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
