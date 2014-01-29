using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;
namespace DataAccess.Controllers
{
    internal class PaymentController: DataController<PaymentEntity>
    {
        private const string FILENAME = "Payments.bin"; 

         public PaymentController()
        {
            binaryHelper = new BinaryHelper<PaymentEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

         internal IPayment Create(IPayment ipa)
         {
             ipa.Id = getNextId();
             ipa.LastUpdated = DateTime.Now;
             ipa.Deleted = false;
             PaymentEntity pe = new PaymentEntity(ipa);
             entities.Add(pe);

             try
             {
                 binaryHelper.Save(FILENAME, entities);
             }
             catch
             {
                 ipa.Deleted = true;
                 throw;
             }

             return ipa;
         }

         internal List<IPayment> GetAll()
         {
             return entities.Cast<IPayment>().ToList();
         }

         internal IPayment Update(IPayment ipa)
         {
             PaymentEntity oldPe = find(ipa);
             ipa.LastUpdated = DateTime.Now;
             PaymentEntity newPe = new PaymentEntity(ipa);

             entities.Remove(oldPe);
             entities.Add(newPe);

             binaryHelper.Save(FILENAME, entities);

             return (IPayment)newPe;
         }

         internal IPayment Delete(IPayment ipa)
         {
             ipa.Deleted = true;
             return Update(ipa);
         }

         private PaymentEntity find(IPayment ipa)
         {
             foreach (PaymentEntity pe in entities)
             {
                 if (pe.Id == ipa.Id)
                 {
                     return pe;
                 }
             }

             return null;
         }



    }
}
