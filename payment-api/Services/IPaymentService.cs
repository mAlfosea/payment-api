using payment_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Services
{
    public interface IPaymentService
    {
        public Task<Payment> CreatePaymentOrder(Payment payment);
    }
}
