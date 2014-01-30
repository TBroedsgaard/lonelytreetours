using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Interfaces;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelFacade mf = new ModelFacade();
            ISupplier s = mf.CreateSupplier();
            s.Name = "Aida Maria";
            mf.UpdateSupplier(s);
            s = mf.CreateSupplier();
            s.Name = "NatureGalapagos";
            mf.UpdateSupplier(s);
            s = mf.CreateSupplier();
            s.Name = "Dann Carlton";
            mf.UpdateSupplier(s);

            Console.ReadLine();

            ModelFacade mf2 = new ModelFacade();
            List<ISupplier> suppliers = mf2.GetSuppliers();
        }
    }
}
