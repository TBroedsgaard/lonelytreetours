using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPaymentContract : IEntity
    {
        DateTime DueDate { get; set; }
        decimal Amount { get; set; }
        string Valuta { get; set; }
        string Invoice { get; set; }
    }
}
