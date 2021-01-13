using Newtonsoft.Json;
using RabbitMQ.Client;
using Data.Models;
using System;
using System.Text;

namespace RabbitMQ.Producer
{
    public static class Producer
    {
        static void Main(string[] args)
        {
        }

        public static void PublishPaymentOrder(Payment payment)
        {
            //borker queue creation
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

            //convert payment in json
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payment));

            //send message to broker
            channel.BasicPublish("", "payment-order", null, body);
        }
    }
}
