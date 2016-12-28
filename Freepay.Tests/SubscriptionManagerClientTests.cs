using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace Freepay.Tests
{
    [TestFixture]
    public class SubscriptionManagerClientTests
    {
        [Test]
        public async Task AuthorizeSubscription_OK_Succesful()
        {
            int subscriptionId = 234234;
            string password = "Password";
            int amount = 20000;
            string orderId = "234234234";
            Currency currency = Currency.DKK;

            var mockHttp = new MockHttpMessageHandler();
            var xmlResponse = @"<?xml version=""1.0"" encoding=""utf-8""?>
<AuthorizationResult xmlns=""http://gw.freepay.dk/WebServices/Public/SubscriptionManager"">
  <IsSuccess>true</IsSuccess>
  <TransactionID>234234234</TransactionID>
  <ErrorCode>0</ErrorCode>
</AuthorizationResult>
";
            mockHttp.When(Urls.GetAuthorizeSubscriptionUrl(subscriptionId, password, amount, orderId, (int)currency))
                    .Respond("text/xml", xmlResponse); 

            var httpClient = new HttpClient(mockHttp) {BaseAddress = new Uri("https://gw.freepay.dk")};
            var client = new SubscriptionManagerClient(httpClient);
            var result = await client.AuthorizeSubscriptionAsync(subscriptionId, password, amount, orderId, currency);
            Assert.NotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual(234234234, result.TransactionID);
            Assert.AreEqual(0, result.ErrorCode);
        }

        [Test]
        public async Task QuerySubscription_Ok_Success()
        {
            int subscriptionId = 234234;
            string password = "Password";

            var mockHttp = new MockHttpMessageHandler();
            var mockXmlResponse = @"<?xml version=""1.0"" encoding=""utf-8""?>
<SubscriptionView xmlns=""http://gw.freepay.dk/WebServices/Public/SubscriptionManager"">
  <SubscriptionID>234234</SubscriptionID>
  <MerchantID>5345</MerchantID>
  <MerchantNumber>34534</MerchantNumber>
  <DateCreated>2016-12-12T15:32:12</DateCreated>
  <Currency>208</Currency>
  <OrderID>3453453</OrderID>
  <CardType>VisaDankort</CardType>
  <SourceIP>195.234.12.4</SourceIP>
  <PANHash>B83EB70F-36BC-48AB-A5E0-DCE51A998A7A</PANHash>
  <ExpiryDate>2016-12-12</ExpiryDate>
  <Acquirer>NetsTeller</Acquirer>
</SubscriptionView>
";

            mockHttp.When(Urls.GetQuerySubscriptionUrl(subscriptionId, password))
                    .Respond("text/xml", mockXmlResponse);
            
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            ISubscriptionManagerClient client = new SubscriptionManagerClient(httpClient);
            var result = await client.QuerySubscriptionAsync(subscriptionId, password);
            Assert.NotNull(result);
            Assert.AreEqual(234234, result.SubscriptionID);
            Assert.AreEqual(5345, result.MerchantID);
            Assert.AreEqual(34534, result.MerchantNumber);
            Assert.AreEqual(new DateTime(2016,12,12,15,32,12), result.DateCreated);
            Assert.AreEqual(208, result.Currency);
            Assert.AreEqual("3453453", result.OrderID);
            Assert.AreEqual("VisaDankort", result.CardType);
            Assert.AreEqual("195.234.12.4", result.SourceIP);
            Assert.AreEqual("B83EB70F-36BC-48AB-A5E0-DCE51A998A7A", result.PANHash);
            Assert.AreEqual(new DateTime(2016, 12, 12), result.ExpiryDate);
            Assert.AreEqual("NetsTeller", result.Acquirer);
        }
    }
}