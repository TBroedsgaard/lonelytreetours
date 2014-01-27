using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class SaleController
    {
        private List<SaleEntity> sales;
        private BinaryHelper<SaleEntity> binaryHelper;
        private const string FILENAME = "sales.bin";
        private int nextId;

        public SaleController()
        {
            binaryHelper = new BinaryHelper<SaleEntity>();
            sales = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal ISale Create(ISale isa)
        {
            isa.Id = getNextId();
            isa.LastUpdated = DateTime.Now;
            isa.Deleted = false;
            SaleEntity se = new SaleEntity(isa);
            sales.Add(se);

            try
            {
                binaryHelper.Save(FILENAME, sales);
            }
            catch
            {
                isa.Deleted = true;
            }

            return isa;
        }

        internal List<ISale> GetAll()
        {
            return sales.Cast<ISale>().ToList();
        }

        internal ISale Update(ISale isa)
        {
            SaleEntity oldSe = find(isa);
            isa.LastUpdated = DateTime.Now;
            SaleEntity newSe = new SaleEntity(isa);

            sales.Remove(oldSe);
            sales.Add(newSe);

            binaryHelper.Save(FILENAME, sales);

            return (ISale)newSe;
        }

        internal ISale Delete(ISale isa)
        {
            isa.Deleted = true;
            return Update(isa);
        }

        private SaleEntity find(ISale isa)
        {
            foreach (SaleEntity se in sales)
            {
                if (se.Id == isa.Id)
                {
                    return se;
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

            foreach (SaleEntity se in sales)
            {
                if (se.Id != null && se.Id > maxId)
                {
                    maxId = (int)se.Id;
                }
            }

            nextId = maxId;
        }
    }
}
