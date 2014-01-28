using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Sale : Entity, ISale
    {
        public SaleStatus SaleStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SpecialRequests { get; set; }
        public ICustomer Customer { get; set; }

        public Sale(ISale iSale)
        {
            Id = iSale.Id;
            Deleted = iSale.Deleted;
            LastUpdated = iSale.LastUpdated;

            CreatedDate = iSale.CreatedDate;
            Customer = iSale.Customer;
            SaleStatus = iSale.SaleStatus;
            SpecialRequests = iSale.SpecialRequests;
        }

        public Sale()
        { }
    }
}
