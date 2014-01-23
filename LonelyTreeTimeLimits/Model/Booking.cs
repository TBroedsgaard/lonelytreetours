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
    }
}
