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

        public bool CreateCustomer(ICustomer iCustomer)
        {
            if (dataAccessFacade.CreateCustomer(iCustomer))
            {
                Customer customer = new Customer(iCustomer);
                customers.Add(customer);

                return true;
            }

            return false;
        }

        public bool UpdateCustomer(ICustomer iCustomer)
        {
            if (dataAccessFacade.UpdateCustomer(iCustomer))
            {
                Customer customer = new Customer(iCustomer); // Creating a new object since I need to add it to the list anyway
                // find customer with id, delete from list, add the new one

                return true;
            }

            return false;
        }

        public bool DeleteCustomer(ICustomer iCustomer)
        {
            if (dataAccessFacade.DeleteCustomer(iCustomer))
            { 
                Customer customer = new Customer(iCustomer); // no need to create new object, just find the one from the iCustomer id
                // find customer with id, set Deleted bit

                return true;
            }

            return false;
        }

        public List<ICustomer> GetCustomers()
        {
            if (customers == null)
            {
                loadCustomers();
            }

            List<ICustomer> iCustomers = customers.Cast<ICustomer>().ToList();
            return iCustomers;
        }

        private void loadCustomers()
        {
            List<ICustomer> iCustomers = dataAccessFacade.GetAllCustomers();

            foreach (ICustomer iCustomer in iCustomers)
            {
                Customer customer = new Customer(iCustomer);
                customers.Add(customer);
            }
        }

        public bool CreateSale(ISale iSale)
        {
            Sale sale = new Sale(iSale);
            if (dataAccessFacade.CreateSale(iSale))
            {
                sales.Add(sale);

                return true;
            }

            return false;
        }

        public bool UpdateSale(ISale iSale)
        {
            if (dataAccessFacade.UpdateSale(iSale))
            {
                Sale sale = new Sale(iSale);
                // find sale with id, delete from list, add the new one
            }
            return false;
        }

        public bool DeleteSale(ISale iSale)
        {
            if (dataAccessFacade.DeleteSale(iSale))
            {
                Sale sale = new Sale(iSale);
                sales.Remove(sale); // TODO: BUG!!! Needs identifier, just as Update does - try typecasting and catch any exceptions? No more ID...

                return true;
            }

            return false;
        }

        public List<ISale> GetSales()
        {
            if (sales == null)
            {
                loadSales();
            }

            List<ISale> iSales = sales.Cast<ISale>().ToList();
            return iSales;
        }

        private void loadSales()
        {
            List<ISale> iSales = dataAccessFacade.GetAllSales();

            foreach (ISale iSale in iSales)
            {
                Sale sale = new Sale(iSale);
                sales.Add(sale);
            }
        }
    }
}
