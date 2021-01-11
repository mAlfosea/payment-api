using Data.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Data.Models;
using RabbitMQ.Consumer.Utils;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    static class Consumer
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("payment-order",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("payment-order", true, consumer);
            Console.ReadLine();
        }

        static void ValidatePayment(byte[] payment)
        {
            Payment validatedPayment = (Payment)Converters.ByteArrayToObject(payment);

            validatedPayment.status = PaymentState.VALIDATED;
        }
    }
}
