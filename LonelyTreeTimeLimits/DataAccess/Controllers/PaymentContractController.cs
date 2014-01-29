using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class PaymentContractController: DataController<PaymentContractEntity>
    {
        private const string FILENAME = "Payments.bin";

        public PaymentContractController()
        {
            binaryHelper = new BinaryHelper<PaymentContractEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal IPaymentContract Create(IPaymentContract isa)
        {
            isa.Id = getNextId();
            isa.LastUpdated = DateTime.Now;
            isa.Deleted = false;
            PaymentContractEntity se = new PaymentContractEntity(isa);
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

        internal List<IPaymentContract> GetAll()
        {
            return entities.Cast<IPaymentContract>().ToList();
        }

        internal IPaymentContract Update(IPaymentContract isa)
        {
            PaymentContractEntity oldSe = find(isa);
            isa.LastUpdated = DateTime.Now;
            PaymentContractEntity newSe = new PaymentContractEntity(isa);

            entities.Remove(oldSe);
            entities.Add(newSe);

            binaryHelper.Save(FILENAME, entities);

            return (IPaymentContract)newSe;
        }

        internal IPaymentContract Delete(IPaymentContract isa)
        {
            isa.Deleted = true;
            return Update(isa);
        }

        private PaymentContractEntity find(IPaymentContract isa)
        {
            foreach (PaymentContractEntity se in entities)
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
