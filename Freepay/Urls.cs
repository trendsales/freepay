using System;

namespace Freepay
{
    public static class Urls
    {
        public static string GetAuthorizeSubscriptionUrl(int subscriptionId, string password, int amount, string orderId, int currencyAsInt)
        {
            return $"/webservices/public/subscriptionmanager.asmx/AuthorizeSubscription3?subscriptionID={subscriptionId}&password={password}&amount={amount}&orderID={orderId}&currency={currencyAsInt}";
        }

        public static string GetQuerySubscriptionUrl(int subscriptionId, string password)
        {
            return
                $"/webservices/public/subscriptionmanager.asmx/QuerySubscription?subscriptionID={subscriptionId}&password={password}";
        }

        public static string GetApproveTransactionUrl(int transactionId, string password)
        {
            return
                $"/webservices/public/management.asmx/ApproveTransaction?transactionID={transactionId}&password={password}";
        }

        public static string GetCaptureUrl(int transactionId, string password)
        {
            return
                $"/webservices/public/management.asmx/CaptureV2?transactionID={transactionId}&password={password}";

        }

        public static string GetChangeCaptureAmountUrl(int transactionId, string password, int amount)
        {
            return
                $"/webservices/public/management.asmx/ChangeCaptureAmount?transactionID={transactionId}&password={password}&amount={amount}";

        }

        public static string GetCreditUrl(int transactionId, string password, int amount)
        {
            return
                $"/webservices/public/management.asmx/CreditV2?transactionID={transactionId}&password={password}&amount={amount}";
        }

        public static string GetDeleteTransactionUrl(int transactionId, string password)
        {
            return
                $"/webservices/public/management.asmx/DeleteTransaction?transactionID={transactionId}&password={password}";

        }

        public static string GetQueryTransactionUrl(int transactionId, string password)
        {
            return
                $"/webservices/public/management.asmx/QueryTransaction?transactionID={transactionId}&password={password}";
        }

        public static string GetSetEarlistCaptureUrl(int transactionId, string password, DateTime earliestCapture)
        {
            return
                   $"/webservices/public/management.asmx/SetEarliestCapture?transactionID={transactionId}&password={password}&earliestCapture={earliestCapture}";

        }

        public static string GetWithholdForApprovalUrl(int transactionId, string password)
        {
            return 
                $"/webservices/public/management.asmx/WithholdForApproval?transactionID={transactionId}&password={password}";
        }
    }
}