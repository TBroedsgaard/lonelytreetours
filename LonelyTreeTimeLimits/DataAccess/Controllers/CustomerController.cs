using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class CustomerController
    {
        private List<CustomerEntity> customers;
        private BinaryHelper<CustomerEntity> binaryHelper;
        private const string FILENAME = "customers.bin";
        private int nextId;

        public CustomerController()
        {
            binaryHelper = new BinaryHelper<CustomerEntity>();
            customers = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal ICustomer Create(ICustomer ic)
        { 
            ic.Id = getNextId();
            ic.LastUpdated = DateTime.Now;
            ic.Deleted = false;
            CustomerEntity ce = new CustomerEntity(ic);
            customers.Add(ce);

            try
            {
                binaryHelper.Save(FILENAME, customers);
            }
            catch
            {
                ic.Deleted = true;
            }


            return ic;
        }

        internal List<ICustomer> GetAll()
        {
            return customers.Cast<ICustomer>().ToList();
        }

        internal ICustomer Update(ICustomer ic)
        {
            CustomerEntity oldCe = find(ic);
            ic.LastUpdated = DateTime.Now;
            CustomerEntity newCe = new CustomerEntity(ic);

            customers.Remove(oldCe);
            customers.Add(newCe);

            binaryHelper.Save(FILENAME, customers);

            return (ICustomer)newCe;
        }

        internal ICustomer Delete(ICustomer ic)
        {
            ic.Deleted = true;
            return Update(ic);
        }

        private CustomerEntity find(ICustomer ic)
        {
            foreach (CustomerEntity ce in customers)
            { 
                if (ce.Id == ic.Id)
                {
                    return ce;
                }
            }

            return null;
        }

        private int? getNextId()
        {
            return nextId++;
        }

        private void setNextId()
        {
            int maxId = 1;

            foreach (CustomerEntity ce in customers)
            {
                if (ce.Id != null && ce.Id > maxId)
                {
                    maxId = (int)ce.Id;
                }
            }

            nextId = maxId;
        }
    }
}
