using System;
using System.Threading.Tasks;

namespace Freepay
{
    public interface IManagementClient
    {
        Task ApproveTransactionAsync(int transactionId, string password);
        Task<TransactionResult> CaptureAsync(int transactionId, string password);
        Task ChangeCaptureAmountAsync(int transactionId, string password, int amount);
        Task<TransactionResult> CreditAsync(int transactionId, string password, int amount);
        Task DeleteTransactionAsync(int transactionId, string password);
        Task<TransactionView> QueryTransactionAsync(int transactionId, string password);
        Task SetEarliestCaptureAsync(int transactionId, string password, DateTime earliestCapture);
        Task WithholdForApprovalAsync(int transactionId, string password);
    }
}