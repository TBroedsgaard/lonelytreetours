using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess.Entities
{
    [Serializable]
    internal class PaymentContractEntity : EntityEntity, IPaymentContract
    {

        public IBooking Booking { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Valuta { get; set; }
        public string Invoice { get; set; }

        public PaymentContractEntity()
        { }

        public PaymentContractEntity(IPaymentContract iPaymentContract)
        {
            Id = iPaymentContract.Id;
            Deleted = iPaymentContract.Deleted;
            LastUpdated = iPaymentContract.LastUpdated;

            Booking = iPaymentContract.Booking;
            DueDate = iPaymentContract.DueDate;
            Amount = iPaymentContract.Amount;
            Valuta = iPaymentContract.Valuta;
            Invoice = iPaymentContract.Invoice;
        }
    }
}
