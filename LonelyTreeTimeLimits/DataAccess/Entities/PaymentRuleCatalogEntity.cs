using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess.Entities
{
    [Serializable]
    internal class PaymentRuleCatalogEntity : EntityEntity, IPaymentRuleCatalog
    {
        public ISupplier Supplier { get; set; }
        public ICustomer Customer { get; set; }
        public BookingType BookingType { get; set; }

        public PaymentRuleCatalogEntity()
        { }

        public PaymentRuleCatalogEntity(IPaymentRuleCatalog iPaymentRuleCatalog)
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
