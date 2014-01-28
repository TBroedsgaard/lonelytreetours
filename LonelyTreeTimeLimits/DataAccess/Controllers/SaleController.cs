using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class SaleController : DataController<SaleEntity>
    {
        private const string FILENAME = "sales.bin";

        public SaleController()
        {
            binaryHelper = new BinaryHelper<SaleEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal ISale Create(ISale isa)
        {
            isa.Id = getNextId();
            isa.LastUpdated = DateTime.Now;
            isa.Deleted = false;
            SaleEntity se = new SaleEntity(isa);
            entities.Add(se);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                isa.Deleted = true;
                throw;
            }

            return isa;
        }

        internal List<ISale> GetAll()
        {
            return entities.Cast<ISale>().ToList();
        }

        internal ISale Update(ISale isa)
        {
            SaleEntity oldSe = find(isa);
            isa.LastUpdated = DateTime.Now;
            SaleEntity newSe = new SaleEntity(isa);

            entities.Remove(oldSe);
            entities.Add(newSe);

            binaryHelper.Save(FILENAME, entities);

            return (ISale)newSe;
        }

        internal ISale Delete(ISale isa)
        {
            isa.Deleted = true;
            return Update(isa);
        }

        private SaleEntity find(ISale isa)
        {
            foreach (SaleEntity se in entities)
            {
                if (se.Id == isa.Id)
                {
                    return se;
                }
            }

            return null;
        }
    }
}
