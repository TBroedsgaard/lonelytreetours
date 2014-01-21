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
        private DataAccessFacade dataAccessFacade;
        private CustomerController customerController;
        private SaleController saleController;

        public ModelFacade()
        {
            dataAccessFacade = new DataAccessFacade();
            customerController = new CustomerController(dataAccessFacade.GetCustomers());
            saleController = new SaleController(dataAccessFacade.GetSales());
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
            iSale = saleController.Create(iSale);
            iSale = dataAccessFacade.CreateSale(iSale);
            if (iSale.Deleted == false)
            {
                saleController.Update(iSale); // update deleted status and set id
            }

            return iSale;
        }

        public ISale UpdateSale(ISale iSale)
        {
            iSale = saleController.Update(iSale);
            dataAccessFacade.UpdateSale(iSale);

            return iSale;
        }

        public bool DeleteSale(ISale iSale)
        {
            iSale = saleController.Delete(iSale);
            if (dataAccessFacade.DeleteSale(iSale))
            {
                return true;
            }

            return false;
        }

        public List<ISale> GetSales()
        {
            return saleController.GetAll();
        }
    }
}
