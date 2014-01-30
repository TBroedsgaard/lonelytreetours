using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    [Serializable]
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

        public Supplier()
        { }

        public Supplier(ISupplier iSupplier)
        {
            Id = iSupplier.Id;
            Deleted = iSupplier.Deleted;
            LastUpdated = iSupplier.LastUpdated;

            SupplierType = iSupplier.SupplierType;
            Name = iSupplier.Name;
            ContactPerson = iSupplier.ContactPerson;
            Email = iSupplier.Email;
            PhoneNumber = iSupplier.PhoneNumber;
            Skype = iSupplier.Skype;
            CreatedDate = iSupplier.CreatedDate;
            Comment = iSupplier.Comment;
            Website = iSupplier.Website;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
