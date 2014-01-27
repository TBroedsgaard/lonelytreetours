using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class SupplierController : ModelController<ISupplier>
    {
        List<Supplier> suppliers;

        public SupplierController(List<ISupplier> iSuppliers)
        {
            suppliers = new List<Supplier>();

            foreach (ISupplier iSupplier in iSuppliers)
            {
                Supplier supplier = new Supplier(iSupplier);
                suppliers.Add(supplier);
            }
        }

        public override ISupplier Create()
        {
            Supplier supplier = new Supplier();
            supplier.Deleted = true;
            suppliers.Add(supplier);

            return (ISupplier)supplier;
        }

        public override ISupplier Update(ISupplier iSupplier)
        {
            Supplier oldSupplier = findSupplier(iSupplier.Id);
            if (oldSupplier == null)
            {
                return null;
            }

            Supplier updatedSupplier = new Supplier(iSupplier);
            suppliers.Remove(oldSupplier);
            suppliers.Add(updatedSupplier);

            return (ISupplier)updatedSupplier;
        }

        public override List<ISupplier> GetAll()
        {
            List<ISupplier> iSuppliers = suppliers.Cast<ISupplier>().ToList();
            return iSuppliers;
        }

        private Supplier findSupplier(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (Supplier supplier in suppliers)
            {
                if (supplier.Id == id)
                {
                    return supplier;
                }
            }

            return null;
        }
    }
}
