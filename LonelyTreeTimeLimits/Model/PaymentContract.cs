using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    [Serializable]
    internal class PaymentContract : Entity, IPaymentContract
    {
        public IBooking Booking { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Valuta { get; set; }
        public string Invoice { get; set; }

        public PaymentContract()
        { }

        public PaymentContract(IPaymentContract iPaymentContract)
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

        public PaymentContract(IBooking iBooking, IPaymentRule iPaymentRule)
        {
            Booking = iBooking;

            if (iPaymentRule.ReferenceDate == ReferenceDate.BookingEndDate)
            {
                DueDate = iBooking.EndDate.AddDays(iPaymentRule.PaymentDate);
            }
            else 
            {
                DueDate = iBooking.StartDate.AddDays(iPaymentRule.PaymentDate);
            }

            Amount = iBooking.TotalAmount * iPaymentRule.Percentage;
            Valuta = iBooking.Valuta;
        }
    }
}
