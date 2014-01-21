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
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(ICustomer iCustomer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(ICustomer iCustomer)
        {
            throw new NotImplementedException();
        }

        public List<ICustomer> GetCustomers()
        {
            // must return empty list and not null
            throw new NotImplementedException();
        }

        public bool UpdateSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public bool CreateSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public List<ISale> GetAllSales()
        {
            throw new NotImplementedException();
        }
    }
}
