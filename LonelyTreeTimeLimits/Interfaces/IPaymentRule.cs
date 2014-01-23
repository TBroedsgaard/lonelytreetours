using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPaymentRule : IEntity
    {
        ReferenceDate ReferenceDate { get; set; }
        int PaymentDate { get; set; }
        decimal Percentage { get; set; }
        string Description { get; set; }
    }
}
