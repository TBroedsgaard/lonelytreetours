using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Booking : Entity, IBooking
    {
        public ISale Sale { get; set; }
        public ISupplier Supplier { get; set; }
        public BookingType BookingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Valuta { get; set; }
        public string Notes { get; set; }

        public Booking()
        { }

        public Booking(IBooking iBooking)
        {
            Id = iBooking.Id;
            Deleted = iBooking.Deleted;
            LastUpdated = iBooking.LastUpdated;

            Sale = iBooking.Sale;
            Supplier = iBooking.Supplier;
            BookingType = iBooking.BookingType;
            StartDate = iBooking.StartDate;
            EndDate = iBooking.EndDate;
            TotalAmount = iBooking.TotalAmount;
            Valuta = iBooking.Valuta;
            Notes = iBooking.Notes;
        }
    }
}
