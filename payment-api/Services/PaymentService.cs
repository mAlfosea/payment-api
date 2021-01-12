using Data.Enums;
using Data.Models;
using RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<Payment> CreatePaymentOrder(Payment payment)
        {
            var acceptedPayment = payment;

            acceptedPayment.TransactionDate = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            acceptedPayment.Status = PaymentState.ACCEPTED;

            Producer.PublishPaymentOrder(payment);

            return acceptedPayment;
        }
    }
}
