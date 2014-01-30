using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess
{
    internal abstract class DataController<T> where T : IEntity
    {
        protected List<T> entities;
        protected BinaryHelper<T> binaryHelper;
        protected int nextId;

        protected int? getNextId()
        {
            return ++nextId;
        }

        protected void setNextId()
        {
            int maxId = 0;

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
