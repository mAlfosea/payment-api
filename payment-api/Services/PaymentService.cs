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
        public Payment CreatePaymentOrder(Payment payment)
        {
            var acceptedPayment = payment;

            //if the amount is not correct we return a null object for the BadRequest() answer
            if (payment.amount <= 0)
            {
                return null;
            }

            //update date et status of the payment order
            acceptedPayment.transactionDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            acceptedPayment.status = PaymentState.ACCEPTED;

            //call Producer project to send payment message
            Producer.PublishPaymentOrder(payment);

            return acceptedPayment;
        }
    }
}
