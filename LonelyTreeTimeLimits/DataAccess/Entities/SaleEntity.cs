using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess.Entities
{
    internal class SaleEntity : EntityEntity, ISale
    {
        public SaleStatus SaleStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SpecialRequests { get; set; }
        public ICustomer Customer { get; set; }

        public SaleEntity(ISale iSale)
        { 
            CreatedDate = iSale.CreatedDate;
            Customer = iSale.Customer;
            SaleStatus = iSale.SaleStatus;
            SpecialRequests = iSale.SpecialRequests;
        }

        public SaleEntity()
        { }
    }
}
