using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class CustomerController : DataController<CustomerEntity>
    {
        private const string FILENAME = "customers.bin";

        public CustomerController()
        {
            binaryHelper = new BinaryHelper<CustomerEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal ICustomer Create(ICustomer ic)
        { 
            ic.Id = getNextId();
            ic.LastUpdated = DateTime.Now;
            ic.Deleted = false;
            CustomerEntity ce = new CustomerEntity(ic);
            entities.Add(ce);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                ic.Deleted = true;
            }


            return ic;
        }

        internal List<ICustomer> GetAll()
        {
            return entities.Cast<ICustomer>().ToList();
        }

        internal ICustomer Update(ICustomer ic)
        {
            CustomerEntity oldCe = find(ic);
            ic.LastUpdated = DateTime.Now;
            CustomerEntity newCe = new CustomerEntity(ic);

            entities.Remove(oldCe);
            entities.Add(newCe);

            binaryHelper.Save(FILENAME, entities);

            return (ICustomer)newCe;
        }

        internal ICustomer Delete(ICustomer ic)
        {
            ic.Deleted = true;
            return Update(ic);
        }

        private CustomerEntity find(ICustomer ic)
        {
            foreach (CustomerEntity ce in entities)
            { 
                if (ce.Id == ic.Id)
                {
                    return ce;
                }
            }

            return null;
        }
    }
}
