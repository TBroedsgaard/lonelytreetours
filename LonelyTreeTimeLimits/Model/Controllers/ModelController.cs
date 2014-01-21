using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal abstract class ModelController<T> where T : IEntity
    {
        public abstract T Create();
        public abstract T Update(T t);
        public T Delete(T t)
        {
            t.Deleted = true;
            return Update(t);
        }
        public abstract List<T> GetAll();
    }
}
