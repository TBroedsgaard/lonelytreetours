using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class PaymentContractController : ModelController<IPaymentContract>
    {
        private List<PaymentContract> paymentContracts;

        public PaymentContractController(List<IPaymentContract> iPaymentContracts)
        {
            paymentContracts = new List<PaymentContract>();

            foreach(IPaymentContract iPaymentContract in iPaymentContracts)
            {
                PaymentContract paymentContract = new PaymentContract(iPaymentContract);
                paymentContracts.Add(paymentContract);
            }
        }

        public override IPaymentContract Create()
        {
            PaymentContract paymentContract = new PaymentContract();
            paymentContract.Deleted = true;
            paymentContracts.Add(paymentContract);

            return paymentContract;
        }

        public IPaymentContract Create(IBooking iBooking, IPaymentRule iPaymentRule)
        {
            PaymentContract paymentContract = new PaymentContract(iBooking, iPaymentRule);
            paymentContract.Deleted = true;
            paymentContracts.Add(paymentContract);

            return paymentContract;
        }

        public override IPaymentContract Update(IPaymentContract iPaymentContract)
        {
            PaymentContract oldPaymentContract = findPaymentContract(iPaymentContract.Id);
            if (oldPaymentContract == null)
            {
                return null;
            }

            PaymentContract updatedPaymentContract = new PaymentContract(iPaymentContract);
            paymentContracts.Remove(oldPaymentContract);
            paymentContracts.Add(updatedPaymentContract);

            return (IPaymentContract)updatedPaymentContract;
        }


        public override List<IPaymentContract> GetAll()
        {
            List<IPaymentContract> iPaymentContracts = paymentContracts.Cast<IPaymentContract>().ToList();
            return iPaymentContracts;
        }

        private PaymentContract findPaymentContract(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (PaymentContract paymentContract in paymentContracts)
            {
                if (paymentContract.Id == id)
                {
                    return paymentContract;
                }
            }

            return null;
        }


    }
}
