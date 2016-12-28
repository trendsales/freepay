using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Freepay
{
    public class SubscriptionManagerClient : ISubscriptionManagerClient
    {
        private readonly HttpClient client;

        // ReSharper disable once UnusedMember.Global
        public SubscriptionManagerClient() : this(new HttpClient() {  BaseAddress = new Uri("https://gw.freepay.dk")})
        {
        }

        public SubscriptionManagerClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AuthorizationResult> AuthorizeSubscriptionAsync(int subscriptionId, string password, int amount, string orderId, Currency currency)
        {
            var currencyAsInt = (int)currency;
            var url = Urls.GetAuthorizeSubscriptionUrl(subscriptionId, password, amount, orderId, currencyAsInt);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<AuthorizationResult>(Formatters.Get());
            return result;
        }

        public async Task<SubscriptionView> QuerySubscriptionAsync(int subscriptionId, string password)
        {
            var url = Urls.GetQuerySubscriptionUrl(subscriptionId, password);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<SubscriptionView>(Formatters.Get());
            return result;
        }
    }
}