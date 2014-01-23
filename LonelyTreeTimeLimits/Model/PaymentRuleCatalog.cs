using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class PaymentRuleCatalog : Entity, IPaymentRuleCatalog
    {
        public ISupplier Supplier { get; set; }
        public ICustomer Customer { get; set; }
        public BookingType BookingType { get; set; }
    }
}
