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

        public PaymentRuleCatalog()
        { }

        public PaymentRuleCatalog(IBooking iBooking)
        {
            Supplier = iBooking.Supplier;
            Customer = iBooking.Sale.Customer;
            BookingType = iBooking.BookingType;
        }

        public PaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            Id = iPaymentRuleCatalog.Id;
            Deleted = iPaymentRuleCatalog.Deleted;
            LastUpdated = iPaymentRuleCatalog.LastUpdated;

            Supplier = iPaymentRuleCatalog.Supplier;
            Customer = iPaymentRuleCatalog.Customer;
            BookingType = iPaymentRuleCatalog.BookingType;
        }
    }
}
