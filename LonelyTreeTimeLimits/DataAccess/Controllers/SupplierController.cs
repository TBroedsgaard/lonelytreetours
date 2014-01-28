using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class SupplierController : DataController<SupplierEntity>
    {
        private const string FILENAME = "suppliers.bin";

        public SupplierController()
        {
            binaryHelper = new BinaryHelper<SupplierEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal ISupplier Create(ISupplier isu)
        {
            isu.Id = getNextId();
            isu.LastUpdated = DateTime.Now;
            isu.Deleted = false;
            SupplierEntity sue = new SupplierEntity(isu);
            entities.Add(sue);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                isu.Deleted = true;
                throw;
            }


            return isu;
        }

        internal List<ISupplier> GetAll()
        {
            return entities.Cast<ISupplier>().ToList();
        }

        internal ISupplier Update(ISupplier isu)
        {
            SupplierEntity oldSue = find(isu);
            isu.LastUpdated = DateTime.Now;
            SupplierEntity newSue = new SupplierEntity(isu);

            entities.Remove(oldSue);
            entities.Add(newSue);

            binaryHelper.Save(FILENAME, entities);

            return (ISupplier)newSue;
        }

        internal ISupplier Delete(ISupplier isu)
        {
            isu.Deleted = true;
            return Update(isu);
        }

        private SupplierEntity find(ISupplier isu)
        {
            foreach (SupplierEntity sue in entities)
            {
                if (sue.Id == isu.Id)
                {
                    return sue;
                }
            }

            return null;
        }
    }
}