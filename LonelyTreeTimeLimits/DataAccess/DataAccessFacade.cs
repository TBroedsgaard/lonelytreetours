using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DataAccess.Entities;
using DataAccess.Controllers;

namespace DataAccess
{
    public class DataAccessFacade
    {
        CustomerController customerController;

        public DataAccessFacade()
        { 
            customerController = new CustomerController();
        }

        public ICustomer CreateCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Create(iCustomer);

            return iCustomer;
        }

        public ICustomer UpdateCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Update(iCustomer);

            return iCustomer;
        }

        public ICustomer DeleteCustomer(ICustomer iCustomer)
        {
            iCustomer = customerController.Delete(iCustomer);

            return iCustomer;
        }

        public List<ICustomer> GetCustomers()
        {
            return customerController.GetAll();
        }

        public ISale CreateSale(ISale iSale)
        {
            iSale.Deleted = false;
            return iSale;
            //throw new NotImplementedException();
        }

        public ISale UpdateSale(ISale iSale)
        {
            return iSale;
        }


        public bool DeleteSale(ISale iSale)
        {
            throw new NotImplementedException();
        }

        public List<ISale> GetSales()
        {
            return new List<ISale>();
        }

        public IPaymentRuleCatalog CreatePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            iPaymentRuleCatalog.Deleted = false;
            return iPaymentRuleCatalog;
        }

        public List<IPaymentRuleCatalog> GetPaymentRuleCatalogs()
        {
            return new List<IPaymentRuleCatalog>();
        }

        public IPaymentContract CreatePaymentContract(IPaymentContract iPaymentContract)
        {
            iPaymentContract.Deleted = false;
            return iPaymentContract;
        }

        public bool UpdatePaymentContract(IPaymentContract iPaymentContract)
        {
            return true;
        }

        public bool UpdatePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            return true;
        }

        public List<IPaymentRule> GetPaymentRules()
        {
            return new List<IPaymentRule>();
        }

        public List<IPaymentContract> GetPaymentContracts()
        {
            return new List<IPaymentContract>();
        }

        public List<IBooking> GetBookings()
        {
            return new List<IBooking>();
        }

        public IBooking CreateBooking(IBooking iBooking)
        {
            iBooking.Deleted = false;
            return iBooking;
        }

        public bool UpdateBooking(IBooking iBooking)
        {
            return true;
        }

        public IPaymentRule CreatePaymentRule(IPaymentRule iPaymentRule)
        {
            iPaymentRule.Deleted = false;
            return iPaymentRule;
        }

        public bool UpdatePaymentRule(IPaymentRule iPaymentRule)
        {
            return true;
        }
    }
}
