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

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            var acceptedPayment = await _paymentService.CreatePaymentOrder(payment);

            if (acceptedPayment == null)
            {
                return BadRequest();
            }

            return Accepted(acceptedPayment);
        }

        // POST: api/Payment
        [HttpPost]
        [Route("/Payment-validation")]
        public async Task<ActionResult> PostPaymentValidation(Payment payment)
        {
            var paymentReceived = payment;

            return NoContent();
        }

        // GET: api/Payment
        [HttpGet]
        [Route("/Payment-validation")]
        public async Task<ActionResult> GetPaymentValidation()
        {
            return NoContent();
        }
    }
}
