using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Freepay.Tests
{
    [TestFixture]
    public class UrlsTests
    {
        [Test]
        public void GetApproveTransactionUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetApproveTransactionUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/management.asmx/ApproveTransaction?transactionID=345345&password=Password", url);
        }

        [Test]
        public void GetCaptureUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetCaptureUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/management.asmx/CaptureV2?transactionID=345345&password=Password", url);
        }

        [Test]
        public void GetChangeCaptureAmountUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            int amount = 200;
            var url = Urls.GetChangeCaptureAmountUrl(transactionId, password, amount);
            Assert.AreEqual("/webservices/public/management.asmx/ChangeCaptureAmount?transactionID=345345&password=Password&amount=200", url);
        }

        [Test]
        public void GetCreditUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            int amount = 200;
            var url = Urls.GetCreditUrl(transactionId, password, amount);
            Assert.AreEqual("/webservices/public/management.asmx/CreditV2?transactionID=345345&password=Password&amount=200", url);
        }

        [Test]
        public void GetDeleteTransactionUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetDeleteTransactionUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/management.asmx/DeleteTransaction?transactionID=345345&password=Password", url);
        }

        [Test]
        public void GetQuerySubscriptionUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetQuerySubscriptionUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/subscriptionmanager.asmx/QuerySubscription?subscriptionID=345345&password=Password", url);
        }

        [Test]
        public void GetQueryTransactionUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetQueryTransactionUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/management.asmx/QueryTransaction?transactionID=345345&password=Password", url);
        }

        [Test]
        public void GetSetEarlistCaptureUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            DateTime earliestCapture = new DateTime(2015, 2, 15);
            var url = Urls.GetSetEarlistCaptureUrl(transactionId, password, earliestCapture);
            Assert.AreEqual("/webservices/public/management.asmx/SetEarliestCapture?transactionID=345345&password=Password&earliestCapture=15-02-2015 00:00:00", url);
        }

        [Test]
        public void GetWithholdForApprovalUrl()
        {
            int transactionId = 345345;
            string password = "Password";
            var url = Urls.GetWithholdForApprovalUrl(transactionId, password);
            Assert.AreEqual("/webservices/public/management.asmx/WithholdForApproval?transactionID=345345&password=Password", url);
        }

        [Test]
        public void Get()
        {
            int transactionId = 345345;
            string password = "Password";
            int amount = 34065;
            string orderId = "545646474";
            int currencyAsInt = 208;
            var url = Urls.GetAuthorizeSubscriptionUrl(transactionId, password, amount, orderId, currencyAsInt);
            Assert.AreEqual("/webservices/public/subscriptionmanager.asmx/AuthorizeSubscription3?subscriptionID=345345&password=Password&amount=34065&orderID=545646474&currency=208", url);
        }
    }
}
