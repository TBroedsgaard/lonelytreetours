using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class SaleController : ModelController<ISale>
    {
        private List<Sale> sales;

        public SaleController(List<ISale> iSales)
        {
            sales = new List<Sale>();

            foreach (ISale iSale in iSales)
            {
                Sale sale = new Sale(iSale);
                sales.Add(sale);
            }
        }

        public override ISale Create()
        {
            Sale sale = new Sale();
            sale.Deleted = true;
            sales.Add(sale);

            return (ISale)sale;
        }

        public override ISale Update(ISale iSale)
        {
            Sale oldSale = findSale(iSale.Id);
            if (oldSale == null)
            {
                return null;
            }

            Sale updatedSale = new Sale(iSale);
            sales.Remove(oldSale);
            sales.Add(updatedSale);

            return (ISale)updatedSale;
        }


        public override List<ISale> GetAll()
        {
            List<ISale> iSales = sales.Cast<ISale>().ToList();
            return iSales;
        }

        private Sale findSale(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (Sale sale in sales)
            {
                if (sale.Id == id)
                {
                    return sale;
                }
            }

            return null;
        }
    }
}
