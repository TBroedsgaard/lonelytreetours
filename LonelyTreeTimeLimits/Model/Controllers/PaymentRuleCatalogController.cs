using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class PaymentRuleCatalogController : ModelController<IPaymentRuleCatalog>
    {
        private List<PaymentRuleCatalog> paymentRuleCatalogs;

        public PaymentRuleCatalogController(List<IPaymentRuleCatalog> iPaymentRuleCatalogs)
        {
            paymentRuleCatalogs = new List<PaymentRuleCatalog>();

            foreach (IPaymentRuleCatalog iPaymentRuleCatalog in iPaymentRuleCatalogs)
            {
                PaymentRuleCatalog paymentRuleCatalog = new PaymentRuleCatalog(iPaymentRuleCatalog);
                paymentRuleCatalogs.Add(paymentRuleCatalog);
            }
        }

        public override IPaymentRuleCatalog Create()
        {
            PaymentRuleCatalog paymentRuleCatalog = new PaymentRuleCatalog();
            paymentRuleCatalog.Deleted = true;
            paymentRuleCatalogs.Add(paymentRuleCatalog);

            return (IPaymentRuleCatalog)paymentRuleCatalog;
        }

        public IPaymentRuleCatalog Create(IBooking iBooking)
        {
            PaymentRuleCatalog paymentRuleCatalog = new PaymentRuleCatalog(iBooking);
            paymentRuleCatalog.Deleted = true;
            paymentRuleCatalogs.Add(paymentRuleCatalog);

            return (IPaymentRuleCatalog)paymentRuleCatalog;
        }

        public override IPaymentRuleCatalog Update(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            PaymentRuleCatalog oldPaymentRuleCatalog = findPaymentRuleCatalog(iPaymentRuleCatalog.Id);
            if (oldPaymentRuleCatalog == null)
            {
                return null;
            }

            PaymentRuleCatalog updatedPaymentRuleCatalog = new PaymentRuleCatalog(iPaymentRuleCatalog);
            paymentRuleCatalogs.Remove(oldPaymentRuleCatalog);
            paymentRuleCatalogs.Add(updatedPaymentRuleCatalog);

            return (IPaymentRuleCatalog)updatedPaymentRuleCatalog;
        }

        public override List<IPaymentRuleCatalog> GetAll()
        {
            List<IPaymentRuleCatalog> iPaymentRuleCatalogs = paymentRuleCatalogs.Cast<IPaymentRuleCatalog>().ToList();
            return iPaymentRuleCatalogs;
        }

        private PaymentRuleCatalog findPaymentRuleCatalog(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (PaymentRuleCatalog paymentRuleCatalog in paymentRuleCatalogs)
            {
                if (paymentRuleCatalog.Id == id)
                {
                    return paymentRuleCatalog;
                }
            }

            return null;
        }

        internal IPaymentRuleCatalog GetPaymentRuleCatalog(IBooking iBooking)
        {
            PaymentRuleCatalog prc = findPaymentRuleCatalog(iBooking);

            return prc;
        }

        private PaymentRuleCatalog findPaymentRuleCatalog(IBooking iBooking)
        {
            foreach (PaymentRuleCatalog prc in paymentRuleCatalogs)
            {
                if (prc.Supplier == iBooking.Supplier
                    && prc.Customer == iBooking.Sale.Customer
                    && prc.BookingType == iBooking.BookingType)
                {
                    return prc;
                }
            }

            return null;
        }
    }
}
