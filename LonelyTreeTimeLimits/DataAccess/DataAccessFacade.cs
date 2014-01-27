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
            iCustomer.Deleted = false;
            return iCustomer;
        }

        public bool UpdateCustomer(ICustomer iCustomer)
        {
            return true;
        }

        public bool DeleteCustomer(ICustomer iCustomer)
        {
            throw new NotImplementedException();
        }

        public List<ICustomer> GetCustomers()
        {
            // must return empty list and not null
            //throw new NotImplementedException();
            List<ICustomer> iCustomers = new List<ICustomer>();
            return iCustomers;
        }

        public bool UpdateSale(ISale iSale)
        {
            return true;
        }

        public ISale CreateSale(ISale iSale)
        {
            iSale.Deleted = false;
            return iSale;
            //throw new NotImplementedException();
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
