using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess
{
    public class DataAccessFacade
    {
        public ICustomer CreateCustomer(ICustomer iCustomer)
        {
            // assign Id here - or in model?
            return null;
        }

        public bool UpdateCustomer(ICustomer iCustomer)
        {
            return true;
        }

        public bool DeleteCustomer(ICustomer iCustomer)
        {
            return true;
        }

        public List<ICustomer> GetCustomers()
        {
            // must return empty list and not null
            List<ICustomer> ICustomerList;
            ICustomerList = new List<ICustomer>();
            return ICustomerList;
        }

        public bool UpdateSale(ISale iSale)
        {
            return false;
        }

        public ISale CreateSale(ISale iSale)
        {
            return iSale;
        }

        public bool DeleteSale(ISale iSale)
        {
            return false;
        }

        public List<ISale> GetSales()
        {
            List<ISale> isales = new List<ISale>(); 
            return isales;
        }
    }
}
