using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string Label { get; set; }
        public string TransactionDate { get; set; }
        public PaymentState Status { get; set; }
    }
}
