using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DataAccess.Entities
{
    [Serializable]
    internal class PaymentRuleEntity : EntityEntity, IPaymentRule
    {
        public IPaymentRuleCatalog PaymentRuleCatalog { get; set; }
        public ReferenceDate ReferenceDate { get; set; }
        public int PaymentDate { get; set; }
        public decimal Percentage { get; set; }
        public string Description { get; set; }

        public PaymentRuleEntity()
        { }

        public PaymentRuleEntity(IPaymentRule iPaymentRule)
        {
            Id = iPaymentRule.Id;
            Deleted = iPaymentRule.Deleted;
            LastUpdated = iPaymentRule.LastUpdated;

            PaymentRuleCatalog = iPaymentRule.PaymentRuleCatalog;
            ReferenceDate = iPaymentRule.ReferenceDate;
            PaymentDate = iPaymentRule.PaymentDate;
            Percentage = iPaymentRule.Percentage;
            Description = iPaymentRule.Description;
        }
    }
}
