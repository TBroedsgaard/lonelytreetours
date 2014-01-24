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
        private PaymentRuleCatalogController paymentRuleCatalogController;
        private PaymentContractController paymentContractController;
        private PaymentRuleController paymentRuleController;
        private BookingController bookingController;

        public ModelFacade()
        {
            dataAccessFacade = new DataAccessFacade();
            customerController = new CustomerController(dataAccessFacade.GetCustomers());
            saleController = new SaleController(dataAccessFacade.GetSales());
            paymentRuleCatalogController = new PaymentRuleCatalogController(dataAccessFacade.GetPaymentRuleCatalogs());
            paymentContractController = new PaymentContractController(dataAccessFacade.GetPaymentContracts());
            paymentRuleController = new PaymentRuleController(dataAccessFacade.GetPaymentRules());
            bookingController = new BookingController(dataAccessFacade.GetBookings());
        }

        public IPaymentRuleCatalog CreatePaymentRuleCatalog(IBooking iBooking)
        {
            IPaymentRuleCatalog iPaymentRuleCatalog = paymentRuleCatalogController.Create(iBooking);
            iPaymentRuleCatalog = dataAccessFacade.CreatePaymentRuleCatalog(iPaymentRuleCatalog);
            if (iPaymentRuleCatalog.Deleted == false)
            {
                UpdatePaymentRuleCatalog(iPaymentRuleCatalog);
            }

            return iPaymentRuleCatalog;
        }

        public IPaymentRuleCatalog UpdatePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            iPaymentRuleCatalog = paymentRuleCatalogController.Update(iPaymentRuleCatalog);
            dataAccessFacade.UpdatePaymentRuleCatalog(iPaymentRuleCatalog);

            return iPaymentRuleCatalog;
        }

        public IPaymentRuleCatalog GetPaymentRuleCatalog(IBooking iBooking)
        {
            IPaymentRuleCatalog prc = paymentRuleCatalogController.GetPaymentRuleCatalog(iBooking);
            if (prc == null)
            {
                prc = CreatePaymentRuleCatalog(iBooking);
            }

            return prc;
        }

        public List<IPaymentRule> GetPaymentRules(IPaymentRuleCatalog iPaymentRuleCatalog)
        { 
            List<IPaymentRule> iPaymentRules = paymentRuleController.GetPaymentRules(iPaymentRuleCatalog);
            return iPaymentRules;
        }

        public List<IPaymentContract> CreatePaymentContracts(IBooking iBooking, List<IPaymentRule> iPaymentRules)
        {
            List<IPaymentContract> newPaymentContracts = new List<IPaymentContract>();

            foreach (IPaymentRule iPaymentRule in iPaymentRules)
            {
                IPaymentContract paymentContract = CreatePaymentContract(iBooking, iPaymentRule);
                newPaymentContracts.Add(paymentContract);
            }

            return newPaymentContracts;
        }

        public IPaymentContract CreatePaymentContract(IBooking iBooking, IPaymentRule iPaymentRule)
        {
            IPaymentContract iPaymentContract = paymentContractController.Create(iBooking, iPaymentRule);
            iPaymentContract = dataAccessFacade.CreatePaymentContract(iPaymentContract);
            if (iPaymentContract.Deleted == false)
            {
                UpdatePaymentContract(iPaymentContract);
            }

            return iPaymentContract;
        }

        public IPaymentContract UpdatePaymentContract(IPaymentContract iPaymentContract)
        {
            iPaymentContract = paymentContractController.Update(iPaymentContract);
            dataAccessFacade.UpdatePaymentContract(iPaymentContract);

            return iPaymentContract;
        }

        public ICustomer CreateCustomer()
        {
            ICustomer iCustomer = customerController.Create();
            iCustomer = dataAccessFacade.CreateCustomer(iCustomer);
            if (iCustomer.Deleted == false)
            {
                UpdateCustomer(iCustomer);
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

        public ISale CreateSale()
        {
            ISale iSale = saleController.Create();
            iSale = dataAccessFacade.CreateSale(iSale);
            if (iSale.Deleted == false)
            {
                UpdateSale(iSale); // update deleted status and set id
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

        public IBooking CreateBooking(ISale sale)
        {
            IBooking iBooking = bookingController.Create();
            iBooking.Sale = sale;
            iBooking = dataAccessFacade.CreateBooking(iBooking);
            if (iBooking.Deleted == false)
            {
                UpdateBooking(iBooking);
            }

            return iBooking;
        }

        private IBooking UpdateBooking(IBooking iBooking)
        {
            iBooking = bookingController.Update(iBooking);
            dataAccessFacade.UpdateBooking(iBooking);

            return iBooking;
        }

        public ISupplier CreateSupplier()
        {
            return new Supplier();
        }

        public IPaymentRule CreatePaymentRule(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            IPaymentRule iPaymentRule = paymentRuleController.Create();
            iPaymentRule.PaymentRuleCatalog = iPaymentRuleCatalog;
            iPaymentRule = dataAccessFacade.CreatePaymentRule(iPaymentRule);
            if (iPaymentRule.Deleted == false)
            {
                UpdatePaymentRule(iPaymentRule);
            }

            return iPaymentRule;
        }

        public IPaymentRule UpdatePaymentRule(IPaymentRule iPaymentRule)
        {
            iPaymentRule = paymentRuleController.Update(iPaymentRule);
            dataAccessFacade.UpdatePaymentRule(iPaymentRule);

            return iPaymentRule;
        }
    }
}
