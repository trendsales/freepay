// ReSharper disable ParameterHidesMember
// ReSharper disable UnusedMember.Global
namespace Freepay
{
    public class PaymentFormBuilder
    {
        private string merchantNumber;
        private int amount;
        private int currency;
        private string orderId;
        private string acceptUrl;
        private string declineUrl;
        private string param;
        private string auxParam;

        private int subscription;
        private string postUrl;

        public PaymentFormBuilder MerchantNumber(string merchantNumber)
        {
            this.merchantNumber = merchantNumber;
            return this;
        }

        public PaymentFormBuilder Amount(int amount)
        {
            this.amount = amount;
            return this;
        }

        public PaymentFormBuilder Currency(Currency currency)
        {
            this.currency = (int)currency;
            return this;
        }

        public PaymentFormBuilder OrderId(string orderId)
        {
            this.orderId = orderId;
            return this;
        }

        public PaymentFormBuilder AcceptUrl(string acceptUrl)
        {
            this.acceptUrl = acceptUrl;
            return this;
        }

        public PaymentFormBuilder DeclineUrl(string declineUrl)
        {
            this.declineUrl = declineUrl;
            return this;
        }

        public PaymentFormBuilder Param(string param)
        {
            this.param = param;
            return this;
        }

        public PaymentFormBuilder AuxParam(string auxParam)
        {
            this.auxParam = auxParam;
            return this;
        }

        public PaymentFormBuilder Subscription(bool subscription)
        {
            if (subscription)
            {
                this.subscription = 1;
            }
            return this;
        }

        public PaymentForm Build()
        {
            PaymentForm form = new PaymentForm {PostUrl = postUrl};
            form.AddField("MerchantNumber", merchantNumber);
            form.AddField("Amount", amount.ToString());
            form.AddField("Currency", currency.ToString());
            form.AddField("OrderID", orderId);
            form.AddField("AcceptURL", acceptUrl);
            form.AddField("DeclineURL", declineUrl);

            if (!string.IsNullOrWhiteSpace(param))
            {
                form.AddField("Param", param);
            }

            if (!string.IsNullOrWhiteSpace(auxParam))
            {
                form.AddField("AuxParam", param);
            }

            if (subscription == 1)
            {
                form.AddField("Subscription", 1.ToString());
            }

            return form;
        }

        public PaymentFormBuilder PostUrl(string postUrl)
        {
            this.postUrl = postUrl;
            return this;
        }
    }
}