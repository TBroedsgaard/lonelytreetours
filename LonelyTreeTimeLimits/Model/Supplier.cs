using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Supplier : Entity, ISupplier
    {
        public SupplierType SupplierType { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Comment { get; set; }
        public string Website { get; set; }
    }
}
