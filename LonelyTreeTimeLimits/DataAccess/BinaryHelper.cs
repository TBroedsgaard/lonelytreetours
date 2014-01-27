using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class BinaryHelper<T>
    {
        public bool Save(string filename, List<T> entities)
        {
            using (FileStream fs = File.Create(filename, 2048, FileOptions.None))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, entities);
            }

            return true;
        }

        public List<T> Load(string filename)
        { 
            List<T> entities = new List<T>();

            try
            {
                using (FileStream fs = File.OpenRead(filename))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    entities = bf.Deserialize(fs) as List<T>;
                }
            }
            catch
            {
                //throw;
            }

            return entities;
        }
    }
}
