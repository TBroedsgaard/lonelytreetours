using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPaymentRuleCatalog : IEntity
    {
        ISupplier Supplier { get; set; }
        ICustomer Customer { get; set; }
        BookingType BookingType { get; set; }
    }
}
