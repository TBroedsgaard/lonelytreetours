using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DataAccess;

namespace Model
{
    public class ModelFacade
    {
        private List<Customer> customers;
        private List<Sale> sales;
        private DataAccessFacade dataAccessFacade;

        public ModelFacade()
        {
            dataAccessFacade = new DataAccessFacade();
        }

        public List<ICustomer> GetAllCustomers()
        {
            List<ICustomer> iCustomers;

            if (customers == null)
            {
                iCustomers = dataAccessFacade.GetAllCustomers();
                foreach (ICustomer iCustomer in iCustomers)
                {
                    Customer customer = new Customer();
                    customer.BirthDate = iCustomer.BirthDate;
                    customer.Comment = iCustomer.Comment;
                    customer.Country = iCustomer.Country;
                    customer.CreatedDate = iCustomer.CreatedDate;
                    customer.CustomerType = iCustomer.CustomerType;
                    customer.Email = iCustomer.Email;
                }
            }

            return null;
        }

        public List<ISale> GetAllSales()
        {
            if (sales == null)
            {
            }

            List<ISale> iSales = sales.Cast<ISale>().ToList();

            return iSales;
        }


    }
}
