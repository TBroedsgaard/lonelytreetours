using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class PaymentController : ModelController<IPayment>
    {
        private List<Payment> payments;

        public PaymentController(List<IPayment> iPayments)
        {
            payments = new List<Payment>();

            foreach (IPayment iPayment in iPayments)
            {
                Payment payment = new Payment(iPayment);
                payments.Add(payment);
            }
        }

        public override IPayment Create()
        {
            Payment payment = new Payment();
            payment.Deleted = true;
            payments.Add(payment);

            return (IPayment)payment;
        }

        public override IPayment Update(IPayment iPayment)
        {
            Payment oldPayment = findPayment(iPayment.Id);
            if (oldPayment == null)
            {
                return null;
            }

            Payment updatedPayment = new Payment(iPayment);
            payments.Remove(oldPayment);
            payments.Add(updatedPayment);

            return (IPayment)updatedPayment;
        }

        public override List<IPayment> GetAll()
        {
            List<IPayment> iPayments = payments.Cast<IPayment>().ToList();
            return iPayments;
        }

        private Payment findPayment(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (Payment payment in payments)
            {
                if (payment.Id == id)
                {
                    return payment;
                }
            }

            return null;
        }
    }
}
