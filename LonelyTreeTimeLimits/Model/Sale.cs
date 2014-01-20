using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Sale : ISale
    {
        public SaleStatus SaleStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SpecialRequests { get; set; }
        public ICustomer Customer { get; set; }
    }
}
