using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using ImpromptuInterface;

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
            List<ICustomer> iCustomers = new List<ICustomer>();

            var customer = new 
            {
                BirthDate = DateTime.Now,
                Comment = "This is a comment",
                Country = "Country",
                CreatedDate = DateTime.Now,
                CustomerType = CustomerType.Person,
                Email = "email",
                FirstName = "Peter",
                LastName = "Olsen",
                PhoneNumber = "12345678",
                Skype = "Skype",
                LastUpdated = DateTime.Now
            };

            ICustomer iCustomer = customer.ActLike<ICustomer>();

            iCustomers.Add(iCustomer);

            return iCustomers;

            
        }

        public bool UpdateSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public ISale CreateSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public List<ISale> GetSales()
        {
            return new List<ISale>();
            //throw new NotImplementedException();
        }
    }
}
