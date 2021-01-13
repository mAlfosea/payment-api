using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Payment
    {
        public string _id { get; set; }
        public long amount { get; set; }
        public string label { get; set; }
        public long? transactionDate { get; set; }
        public PaymentState status { get; set; }
    }
}
