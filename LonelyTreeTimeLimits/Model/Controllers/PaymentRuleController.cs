using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class PaymentRuleController : ModelController<IPaymentRule>
    {
        private List<PaymentRule> paymentRules;

        public PaymentRuleController(List<IPaymentRule> iPaymentRules)
        {
            paymentRules = new List<PaymentRule>();

            foreach (IPaymentRule iPaymentRule in iPaymentRules)
            {
                PaymentRule paymentRule = new PaymentRule(iPaymentRule);
                paymentRules.Add(paymentRule);
            }
        }

        public override IPaymentRule Create()
        {
            PaymentRule paymentRule = new PaymentRule();
            paymentRule.Deleted = true;
            paymentRules.Add(paymentRule);

            return (IPaymentRule)paymentRule;
        }

        public override IPaymentRule Update(IPaymentRule iPaymentRule)
        {
            PaymentRule oldPaymentRule = findPaymentRule(iPaymentRule.Id);
            if (oldPaymentRule == null)
            {
                return null;
            }

            PaymentRule updatedPaymentRule = new PaymentRule(iPaymentRule);
            paymentRules.Remove(oldPaymentRule);
            paymentRules.Add(updatedPaymentRule);

            return (IPaymentRule)updatedPaymentRule;
        }

        public override List<IPaymentRule> GetAll()
        {
            List<IPaymentRule> iPaymentRules = paymentRules.Cast<IPaymentRule>().ToList();
            return iPaymentRules;
        }

        private PaymentRule findPaymentRule(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (PaymentRule paymentRule in paymentRules)
            {
                if (paymentRule.Id == id)
                {
                    return paymentRule;
                }
            }

            return null;
        }
    }
}
