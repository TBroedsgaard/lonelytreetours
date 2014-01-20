using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICustomer
    {
        CustomerType CustomerType { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        DateTime BirthDate { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Skype { get; set; }
        string Comment { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
