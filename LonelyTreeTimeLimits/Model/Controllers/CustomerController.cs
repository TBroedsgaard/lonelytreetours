using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class CustomerController : ModelController<ICustomer>
    {
        private List<Customer> customers;

        public CustomerController(List<ICustomer> iCustomers)
        {
            customers = new List<Customer>();

            foreach (ICustomer iCustomer in iCustomers)
            {
                Customer customer = new Customer(iCustomer);
                customers.Add(customer);
            }
        }

        public override ICustomer Create(ICustomer iCustomer)
        {
            Customer customer = new Customer(iCustomer);
            customer.Deleted = true; // set as deleted, only when saved in dataAccess it can be set as Undeleted
            customers.Add(customer);

            return (ICustomer)customer;
        }

        public override ICustomer Update(ICustomer iCustomer)
        {
            Customer oldCustomer = findCustomer(iCustomer.Id);
            if (oldCustomer == null)
            {
                return null;
            }

            Customer updatedCustomer = new Customer(iCustomer);
            customers.Remove(oldCustomer);
            customers.Add(updatedCustomer);

            return (ICustomer)updatedCustomer;
        }

        public override List<ICustomer> GetAll()
        {
            List<ICustomer> iCustomers = customers.Cast<ICustomer>().ToList();
            return iCustomers;
        }

        private Customer findCustomer(int? id)
        {
            if (id == null) 
                return null;

            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}
