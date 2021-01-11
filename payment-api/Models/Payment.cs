using payment_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string Time { get; set; }
        public PaymentState status { get; set; }
    }
}
