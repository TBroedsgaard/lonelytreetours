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
        SaleController saleController;
        PaymentRuleCatalogController paymentRuleCatalogController;
        PaymentContractController paymentContractController;
        PaymentRuleController paymentRuleController;
        BookingController bookingController;
        PaymentController paymentController;
        SupplierController supplierController;

        public DataAccessFacade()
        { 
            customerController = new CustomerController();
            saleController = new SaleController();
            paymentRuleCatalogController = new PaymentRuleCatalogController();
            paymentContractController = new PaymentContractController();
            paymentRuleController = new PaymentRuleController();
            bookingController = new BookingController();
            paymentController = new PaymentController();
            supplierController = new SupplierController(); 
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
            iSale = saleController.Create(iSale);

            return iSale;
        }

        public ISale UpdateSale(ISale iSale)
        {
            iSale = saleController.Update(iSale);

            return iSale;
        }


        public ISale DeleteSale(ISale iSale)
        {
            iSale = saleController.Delete(iSale);

            return iSale;
        }

        public List<ISale> GetSales()
        {
            return saleController.GetAll();
        }

        public IPaymentRuleCatalog CreatePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            iPaymentRuleCatalog = paymentRuleCatalogController.Create(iPaymentRuleCatalog);

            return iPaymentRuleCatalog;
        }

        public IPaymentRuleCatalog UpdatePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            iPaymentRuleCatalog = paymentRuleCatalogController.Update(iPaymentRuleCatalog);

            return iPaymentRuleCatalog;
        }

        public IPaymentRuleCatalog DeletePaymentRuleCatalog(IPaymentRuleCatalog iPaymentRuleCatalog)
        {
            iPaymentRuleCatalog = paymentRuleCatalogController.Delete(iPaymentRuleCatalog);

            return iPaymentRuleCatalog;
        }

        public List<IPaymentRuleCatalog> GetPaymentRuleCatalogs()
        {
            return paymentRuleCatalogController.GetAll();
        }

        public IPaymentContract CreatePaymentContract(IPaymentContract iPaymentContract)
        {
            iPaymentContract = paymentContractController.Create(iPaymentContract);

            return iPaymentContract;
        }

        public IPaymentContract UpdatePaymentContract(IPaymentContract iPaymentContract)
        {
            iPaymentContract = paymentContractController.Update(iPaymentContract);

            return iPaymentContract;
        }

        public IPaymentContract DeletePaymentContract(IPaymentContract iPaymentContract)
        {
            iPaymentContract = paymentContractController.Delete(iPaymentContract);

            return iPaymentContract;
        }

        public List<IPaymentContract> GetPaymentContracts()
        {
            return paymentContractController.GetAll();
        }

        public IPaymentRule CreatePaymentRule(IPaymentRule iPaymentRule)
        {
            iPaymentRule = paymentRuleController.Create(iPaymentRule);

            return iPaymentRule;
        }

        public IPaymentRule UpdatePaymentRule(IPaymentRule iPaymentRule)
        {
            iPaymentRule = paymentRuleController.Update(iPaymentRule);

            return iPaymentRule;
        }

        public IPaymentRule DeletePaymentRule(IPaymentRule iPaymentRule)
        {
            iPaymentRule = paymentRuleController.Delete(iPaymentRule);

            return iPaymentRule;
        }

        public List<IPaymentRule> GetPaymentRules()
        {
            return paymentRuleController.GetAll();
        }

        public IBooking CreateBooking(IBooking iBooking)
        {
            iBooking = bookingController.Create(iBooking);

            return iBooking;
        }

        public IBooking UpdateBooking(IBooking iBooking)
        {
            iBooking = bookingController.Update(iBooking);

            return iBooking;
        }

        public IBooking DeleteBooking(IBooking iBooking)
        {
            iBooking = bookingController.Delete(iBooking);

            return iBooking;
        }

        public List<IBooking> GetBookings()
        {
            return bookingController.GetAll();
        }

        public IPayment CreatePayment(IPayment iPayment)
        {
            iPayment = paymentController.Create(iPayment);

            return iPayment;
        }

        public IPayment UpdatePayment(IPayment iPayment)
        {
            iPayment = paymentController.Update(iPayment);

            return iPayment;
        }

        public IPayment DeletePayment(IPayment iPayment)
        {
            iPayment = paymentController.Delete(iPayment);

            return iPayment;
        }

        public List<IPayment> GetPayments()
        {
            return paymentController.GetAll();
        }

        public ISupplier CreateSupplier(ISupplier iSupplier)
        {
            iSupplier = supplierController.Create(iSupplier);

            return iSupplier;
        }

        public ISupplier UpdateSupplier(ISupplier iSupplier)
        {
            iSupplier = supplierController.Update(iSupplier);

            return iSupplier;
        }

        public ISupplier DeleteSupplier(ISupplier iSupplier)
        {
            iSupplier = supplierController.Delete(iSupplier);

            return iSupplier;
        }

        public List<ISupplier> GetSuppliers()
        {
            return supplierController.GetAll();
        }

        public bool savecustomer()
        {
            return true;
        }
    }
}
