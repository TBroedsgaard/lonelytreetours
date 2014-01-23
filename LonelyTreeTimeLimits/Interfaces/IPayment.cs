using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPayment : IEntity
    {
        DateTime PaymentDate { get; set; }
        decimal PayedAmount { get; set; }
        string PaymentReceipt { get; set; }
    }
}
