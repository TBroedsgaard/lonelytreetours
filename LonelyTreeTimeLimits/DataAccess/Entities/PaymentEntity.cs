using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess.Entities
{
    [Serializable]
    internal class PaymentEntity : EntityEntity, IPayment
    {
        public IPaymentContract PaymentContract { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PayedAmount { get; set; }
        public string PaymentReceipt { get; set; }

        public PaymentEntity()
        { }

        public PaymentEntity(IPayment iPayment)
        {
            Id = iPayment.Id;
            Deleted = iPayment.Deleted;
            LastUpdated = iPayment.LastUpdated;

            PaymentContract = iPayment.PaymentContract;
            PaymentDate = iPayment.PaymentDate;
            PayedAmount = iPayment.PayedAmount;
            PaymentReceipt = iPayment.PaymentReceipt;
        }
    }
}
