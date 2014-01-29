using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class PaymentRuleController : DataController<PaymentRuleEntity>
    {
        private const string FILENAME = "PaymentRule.bin";


        public PaymentRuleController()
        {
            binaryHelper = new BinaryHelper<PaymentRuleEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal IPaymentRule Create(IPaymentRule isa)
        {
            isa.Id = getNextId();
            isa.LastUpdated = DateTime.Now;
            isa.Deleted = false;
            PaymentRuleEntity se = new PaymentRuleEntity(isa);
            entities.Add(se);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                isa.Deleted = true;
                se.Deleted = true;
                throw;
            }

            return isa;
        }

        internal List<IPaymentRule> GetAll()
        {
            return entities.Cast<IPaymentRule>().ToList();
        }

        internal IPaymentRule Update(IPaymentRule isa)
        {
            PaymentRuleEntity oldSe = find(isa);
            isa.LastUpdated = DateTime.Now;
            PaymentRuleEntity newSe = new PaymentRuleEntity(isa);

            entities.Remove(oldSe);
            entities.Add(newSe);

            binaryHelper.Save(FILENAME, entities);

            return (IPaymentRule)newSe;
        }

        internal IPaymentRule Delete(IPaymentRule isa)
        {
            isa.Deleted = true;
            return Update(isa);
        }

        private PaymentRuleEntity find(IPaymentRule isa)
        {
            foreach (PaymentRuleEntity se in entities)
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
