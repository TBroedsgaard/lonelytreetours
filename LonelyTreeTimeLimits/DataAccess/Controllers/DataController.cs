using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DataAccess.Entities;

namespace DataAccess
{
    internal class DataController<TInterface, TEntity> 
        where TInterface : IEntity
        where TEntity : TInterface
    {
        private List<TEntity> entities;
        private BinaryHelper<TEntity> binaryHelper;
        private int nextId;
        private string FILENAME;

        public DataController(string filename)
        {
            FILENAME = filename;
            binaryHelper = new BinaryHelper<TEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal TInterface Create(TInterface ic)
        { 
            ic.Id = getNextId();
            ic.LastUpdated = DateTime.Now;
            ic.Deleted = false;
            //TEntity ce = new TEntity(ic);
            object[] myArgs = new object[] {ic};
            TEntity ce = (TEntity)Activator.CreateInstance(typeof(TEntity), myArgs);
            entities.Add(ce);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                ic.Deleted = true;
                throw;
            }


            return ic;
        }

        internal List<TInterface> GetAll()
        {
            return entities.Cast<TInterface>().ToList();
        }

        internal TInterface Update(TInterface ic)
        {
            TEntity oldCe = find(ic);
            ic.LastUpdated = DateTime.Now;
            //CustomerEntity newCe = new CustomerEntity(ic);
            object[] myArgs = new object[] {ic};
            TEntity newCe = (TEntity)Activator.CreateInstance(typeof(TEntity), myArgs);

            entities.Remove(oldCe);
            entities.Add(newCe);

            binaryHelper.Save(FILENAME, entities);

            return newCe;
        }

        internal TInterface Delete(TInterface ic)
        {
            ic.Deleted = true;
            return Update(ic);
        }

        private TEntity find(TInterface ic)
        {
            foreach (TEntity ce in entities)
            { 
                if (ce.Id == ic.Id)
                {
                    return ce;
                }
            }

            return default(TEntity);
        }

        private int? getNextId()
        {
            return nextId++;
        }

        private void setNextId()
        {
            int maxId = 1;

            foreach (IEntity entity in entities)
            {
                if (entity.Id != null && entity.Id > maxId)
                {
                    maxId = (int)entity.Id;
                }
            }

            nextId = maxId;
        }
    }
}
