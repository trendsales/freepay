using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace Freepay.Tests
{
    [TestFixture]
    public class ManagementClientTests
    {
        [Test]
        public async Task ApproveTransaction_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetApproveTransactionUrl(transactionId, password))
                .Respond(HttpStatusCode.OK);

            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            await client.ApproveTransactionAsync(transactionId, password);

            mockHttp.Expect(HttpMethod.Get, "https://gw.freepay.dk" + Urls.GetApproveTransactionUrl(transactionId, password));
        }

        [Test]
        public async Task Capture_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";

            var mockXmlResponse =
                @"<?xml version='1.0' encoding='utf-8'?>
<TransactionResult xmlns=""http://gw.freepay.dk/WebServices/Public/Management"">
  <AcquirerStatusCode>234</AcquirerStatusCode>
  <IsSuccess>true</IsSuccess>
</TransactionResult>";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetCaptureUrl(transactionId, password))
                .Respond("text/xml", mockXmlResponse);
            // Inject the handler or client into your application code
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            var result = await client.CaptureAsync(transactionId, password);
            Assert.NotNull(result);
            Assert.AreEqual(234, result.AcquirerStatusCode);
            Assert.True(result.IsSuccess);
        }

        [Test]
        public async Task ChangeCaptureAmount_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";
            int amount = 2000;

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetChangeCaptureAmountUrl(transactionId, password, amount))
                .Respond(HttpStatusCode.OK);
            // Inject the handler or client into your application code
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            await client.ChangeCaptureAmountAsync(transactionId, password, amount);
        }

        [Test]
        public async Task Credit_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";
            int amount = 200;

            var mockXmlResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
<TransactionResult xmlns=""http://gw.freepay.dk/WebServices/Public/Management"">
  <AcquirerStatusCode>2343</AcquirerStatusCode>
  <IsSuccess>true</IsSuccess>
</TransactionResult>";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetCreditUrl(transactionId, password, amount))
                .Respond("text/xml", mockXmlResponse);
            // Inject the handler or client into your application code
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            var result = await client.CreditAsync(transactionId, password, amount);
            Assert.NotNull(result);
            Assert.AreEqual(2343, result.AcquirerStatusCode);
            Assert.True(result.IsSuccess);
        }

        [Test]
        public async Task DeleteTransaction_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetDeleteTransactionUrl(transactionId, password))
                .Respond(HttpStatusCode.OK);
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            await client.DeleteTransactionAsync(transactionId, password);
        }

        [Test]
        public async Task QueryTransaction_Ok_Success()
        {
            int transactionId = 534536434;
            string password = "Password";

            var mockXmlResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
<TransactionView xmlns=""http://gw.freepay.dk/WebServices/Public/Management"">
  <TransactionID>534536434</TransactionID>
  <MerchantID>23423</MerchantID>
  <MerchantNumber>2342</MerchantNumber>
  <DateCreated>2016-12-12T09:01:04</DateCreated>
  <DateAuthorized>2016-12-12T09:01:05</DateAuthorized>
  <DateCaptured>2016-12-12T09:01:00</DateCaptured>
  <Currency>208</Currency>
  <OrderID>53453463</OrderID>
  <CardType>VisaDankort</CardType>
  <SourceIP>232.42.56.4</SourceIP>
  <AuthorizationAmount>200</AuthorizationAmount>
  <IsCaptured>true</IsCaptured>
  <CaptureAmount>200</CaptureAmount>
  <CaptureErrorCode>0</CaptureErrorCode>
  <DateEarliestCapture>2016-12-12</DateEarliestCapture>
  <IsAwaitingApproval>false</IsAwaitingApproval>
  <PANHash>A54CFE59-31BD-457C-8A38-D5220A8C1C31</PANHash>
  <Acquirer>NetsTeller</Acquirer>
</TransactionView>";

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetQueryTransactionUrl(transactionId, password))
                .Respond("text/xml", mockXmlResponse);
            // Inject the handler or client into your application code
            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            var result = await client.QueryTransactionAsync(transactionId, password);
            Assert.NotNull(result);
            Assert.AreEqual(534536434, result.TransactionID);
            Assert.AreEqual(23423, result.MerchantID);
            Assert.AreEqual(2342, result.MerchantNumber);
            Assert.AreEqual(new DateTime(2016, 12, 12, 9, 1, 4), result.DateCreated);
            Assert.AreEqual(new DateTime(2016, 12, 12, 9, 1, 5), result.DateAuthorized);
            Assert.AreEqual(new DateTime(2016, 12, 12, 9, 1, 0), result.DateCaptured);
            Assert.AreEqual(208, result.Currency);
            Assert.AreEqual("232.42.56.4", result.SourceIP);
            Assert.AreEqual("53453463", result.OrderID);
            Assert.AreEqual("VisaDankort", result.CardType);
            Assert.AreEqual(200, result.AuthorizationAmount);
            Assert.True(result.IsCaptured);
            Assert.AreEqual(200, result.CaptureAmount);
            Assert.AreEqual(0, result.CaptureErrorCode);
            Assert.AreEqual(new DateTime(2016,12,12), result.DateEarliestCapture);
            Assert.False(result.IsAwaitingApproval);
            Assert.AreEqual("A54CFE59-31BD-457C-8A38-D5220A8C1C31", result.PANHash);
            Assert.AreEqual("NetsTeller", result.Acquirer);
        }

        [Test]
        public async Task SetEarliestCapture_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";
            DateTime earliestCapture = new DateTime(2018, 12, 1);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetSetEarlistCaptureUrl(transactionId, password, earliestCapture))
                .Respond(HttpStatusCode.OK);

            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            await client.SetEarliestCaptureAsync(transactionId, password, earliestCapture);
        }

        [Test]
        public async Task WithholdForApproval_OK_Success()
        {
            int transactionId = 534536434;
            string password = "Password";
            DateTime earliestCapture = new DateTime(2018, 12, 1);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(Urls.GetWithholdForApprovalUrl(transactionId, password))
                .Respond(HttpStatusCode.OK);

            var httpClient = new HttpClient(mockHttp) { BaseAddress = new Uri("https://gw.freepay.dk") };
            IManagementClient client = new ManagementClient(httpClient);
            await client.WithholdForApprovalAsync(transactionId, password);
        }
    }
}