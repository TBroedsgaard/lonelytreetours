using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class PaymentRuleCatalogController : DataController<PaymentRuleCatalogEntity>
    {
        private const string FILENAME = "paymentrulecatalog.bin";

        public PaymentRuleCatalogController()
        {
            binaryHelper = new BinaryHelper<PaymentRuleCatalogEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal IPaymentRuleCatalog Create(IPaymentRuleCatalog iprc)
        {
            iprc.Id = getNextId();
            iprc.LastUpdated = DateTime.Now;
            iprc.Deleted = false;
            PaymentRuleCatalogEntity prce = new PaymentRuleCatalogEntity(iprc);
            entities.Add(prce);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                iprc.Deleted = true;
                prce.Deleted = true;
                throw;
            }


            return iprc;
        }

        internal List<IPaymentRuleCatalog> GetAll()
        {
            return entities.Cast<IPaymentRuleCatalog>().ToList();
        }

        internal IPaymentRuleCatalog Update(IPaymentRuleCatalog iprc)
        {
            PaymentRuleCatalogEntity oldPrce = find(iprc);
            iprc.LastUpdated = DateTime.Now;
            PaymentRuleCatalogEntity newPrce = new PaymentRuleCatalogEntity(iprc);

            entities.Remove(oldPrce);
            entities.Add(newPrce);

            binaryHelper.Save(FILENAME, entities);

            return (IPaymentRuleCatalog)newPrce;
        }

        internal IPaymentRuleCatalog Delete(IPaymentRuleCatalog iprc)
        {
            iprc.Deleted = true;
            return Update(iprc);
        }

        private PaymentRuleCatalogEntity find(IPaymentRuleCatalog iprc)
        {
            foreach (PaymentRuleCatalogEntity prce in entities)
            {
                if (prce.Id == iprc.Id)
                {
                    return prce;
                }
            }

            return null;
        }
    }
}