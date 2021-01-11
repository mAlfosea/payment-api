using payment_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task CreatePaymentOrder(Payment payment)
        {
            //TODO call broker 
        }
    }
}
