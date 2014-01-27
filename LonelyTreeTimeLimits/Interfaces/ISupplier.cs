using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISupplier : IEntity
    {
        SupplierType SupplierType { get; set; }
        string Name { get; set; }
        string ContactPerson { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Skype { get; set; }
        DateTime CreatedDate { get; set; }
        string Comment { get; set; }
        string Website { get; set; }
    }
}
