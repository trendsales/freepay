using System.Threading.Tasks;

namespace Freepay
{
    public interface ISubscriptionManagerClient
    {
        Task<AuthorizationResult> AuthorizeSubscriptionAsync(int subscriptionId, string password, int amount, string orderId, Currency currency);
        Task<SubscriptionView> QuerySubscriptionAsync(int subscriptionId, string password);
    }
}