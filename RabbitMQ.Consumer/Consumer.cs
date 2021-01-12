using Data.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Data.Models;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

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
                ValidatePayment(body);
            };
            channel.BasicConsume("payment-order", true, consumer);

            Console.ReadLine();
        }

        static void ValidatePayment(byte[] paymentBytes)
        {
            var paymentString = Encoding.UTF8.GetString(paymentBytes);
            var payment = JsonConvert.DeserializeObject<Payment>(paymentString);

            payment.TransactionDate = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            payment.Status = PaymentState.VALIDATED;

            Console.WriteLine(paymentString);

            PostValidatedPayment(payment);
        }

        static async void PostValidatedPayment(Payment payment)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/payment-validation");

            var response = await client.PostAsync(client.BaseAddress, new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));

            if (response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }
    }
}
