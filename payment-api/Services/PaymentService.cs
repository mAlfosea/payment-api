using payment_api.Models;
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

            acceptedPayment.Time = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            acceptedPayment.status = Enums.PaymentState.ACCEPTED;

            return acceptedPayment;
        }
    }
}
