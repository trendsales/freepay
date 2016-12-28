using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Freepay
{
    public class ManagementClient : IManagementClient
    {
        private readonly HttpClient client;

        public ManagementClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task ApproveTransactionAsync(int transactionId, string password)
        {
            var url = Urls.GetApproveTransactionUrl(transactionId, password);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public async Task<TransactionResult> CaptureAsync(int transactionId, string password)
        {
            var url = Urls.GetCaptureUrl(transactionId, password);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<TransactionResult>(Formatters.Get());
            return result;
        }

        public async Task ChangeCaptureAmountAsync(int transactionId, string password, int amount)
        {
            var url = Urls.GetChangeCaptureAmountUrl(transactionId, password, amount);
            var response = await client.GetAsync(url);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Failed to change capture amount to " + amount +"  on transaction with id: " + transactionId + " Freepay status code was " + response.StatusCode + " (" + response.ReasonPhrase + ")");
            }
        }

        public async Task<TransactionResult> CreditAsync(int transactionId, string password, int amount)
        {
            var url = Urls.GetCreditUrl(transactionId, password, amount);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<TransactionResult>(Formatters.Get());
            return result;
        }

        public async Task DeleteTransactionAsync(int transactionId, string password)
        {
            var url = Urls.GetDeleteTransactionUrl(transactionId, password);
            var response = await client.GetAsync(url);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Failed to delete transaction with transactionId: "  + transactionId);
            }

        }

        public async Task<TransactionView> QueryTransactionAsync(int transactionId, string password)
        {
            var url = Urls.GetQueryTransactionUrl(transactionId, password); 
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<TransactionView>(Formatters.Get());
            return result;
        }

        public async Task SetEarliestCaptureAsync(int transactionId, string password, DateTime earliestCapture)
        {
            var url = Urls.GetSetEarlistCaptureUrl(transactionId, password, earliestCapture);
            var response = await client.GetAsync(url);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Failed to set earlist capture date to: " + earliestCapture + " on transaction with id: " + transactionId);
            }
        }

        public async Task WithholdForApprovalAsync(int transactionId, string password)
        {
            var url = Urls.GetWithholdForApprovalUrl(transactionId, password);
            var response = await client.GetAsync(url);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Failed to withhold for approval  on transaction with id: " + transactionId);
            }
        }
    }
}