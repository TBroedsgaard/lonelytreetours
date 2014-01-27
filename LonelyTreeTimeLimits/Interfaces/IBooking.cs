using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBooking : IEntity
    {
        ISale Sale { get; set; }
        ISupplier Supplier { get; set; }
        BookingType BookingType { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        decimal TotalAmount { get; set; }
        string Valuta { get; set; }
        string Notes { get; set; }
    }
}
