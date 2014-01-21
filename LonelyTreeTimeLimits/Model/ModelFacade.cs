using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DataAccess;
using Model.Controllers;

namespace Model
{
    public class ModelFacade
    {
        private List<Sale> sales;
        private DataAccessFacade dataAccessFacade;
        private CustomerController customerController;

        public ModelFacade()
        {
            dataAccessFacade = new DataAccessFacade();
            customerController = new CustomerController(dataAccessFacade.GetCustomers());
        }

        public ICustomer CreateCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Create(iCustomer);
            iCustomer = dataAccessFacade.CreateCustomer(iCustomer);
            if (iCustomer.Deleted == false)
            {
                customerController.Update(iCustomer);
            }

            return iCustomer;
        }

        public ICustomer UpdateCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Update(iCustomer);
            dataAccessFacade.UpdateCustomer(iCustomer);

            return iCustomer;
        }

        public bool DeleteCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Delete(iCustomer);
            if (dataAccessFacade.DeleteCustomer(iCustomer))
            {
                return true;
            }

            return false;
        }

        public List<ICustomer> GetCustomers()
        {
            return customerController.GetAll();
        }

        public ISale CreateSale(ISale iSale)
        {
            Sale sale = new Sale(iSale);
            if (dataAccessFacade.CreateSale(iSale))
            {
                sales.Add(sale);
            }

            return (ISale)sale;
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
