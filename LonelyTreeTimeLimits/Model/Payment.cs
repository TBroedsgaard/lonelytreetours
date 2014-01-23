using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Payment : Entity, IPayment
    {
        public IPaymentContract PaymentContract { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PayedAmount { get; set; }
        public string PaymentReceipt { get; set; }
    }
}
