using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class PaymentContract : Entity, IPaymentContract
    {
        public IBooking Booking { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Valuta { get; set; }
        public string Invoice { get; set; }
    }
}
