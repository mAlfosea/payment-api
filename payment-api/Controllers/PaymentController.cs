using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.Models;
using payment_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        // POST: Payment
        [HttpPost]
        public ActionResult<Payment> PostPayment(Payment payment)
        {
            //call function to create the payment order
            var acceptedPayment = _paymentService.CreatePaymentOrder(payment);

            //if the accepted payment is null, it's because we have an error in datas
            if (acceptedPayment == null)
            {
                return BadRequest();
            }

            return Accepted(acceptedPayment);
        }
    }
}
