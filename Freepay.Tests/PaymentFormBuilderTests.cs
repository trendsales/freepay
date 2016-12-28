using System.Linq;
using System.Net.Http;
using NUnit.Framework;

namespace Freepay.Tests
{
    [TestFixture]
    public class PaymentFormBuilderTests
    {
        [Test]
        public void CreateForm()
        {
            var form = new PaymentFormBuilder()
                .PostUrl("http://freepay.dk")
                .MerchantNumber("2342342")
                .Amount(20000)
                .Currency(Currency.DKK)
                .OrderId("124234234")
                .AcceptUrl("http://example.com/accept")
                .DeclineUrl("http://example.com/decline")
                .Build();

            Assert.AreEqual("http://freepay.dk", form.PostUrl);
            var fields = form.Fields.ToArray();
            Assert.AreEqual(6, fields.Length);
            Assert.AreEqual("MerchantNumber", fields[0].Name);
            Assert.AreEqual("2342342", fields[0].Value);
            Assert.AreEqual("Amount", fields[1].Name);
            Assert.AreEqual("20000", fields[1].Value);
            Assert.AreEqual("Currency", fields[2].Name);
            Assert.AreEqual("208", fields[2].Value);
            Assert.AreEqual("OrderID", fields[3].Name);
            Assert.AreEqual("124234234", fields[3].Value);
            Assert.AreEqual("AcceptURL", fields[4].Name);
            Assert.AreEqual("http://example.com/accept", fields[4].Value);
            Assert.AreEqual("DeclineURL", fields[5].Name);
            Assert.AreEqual("http://example.com/decline", fields[5].Value);
        }
    }
}
