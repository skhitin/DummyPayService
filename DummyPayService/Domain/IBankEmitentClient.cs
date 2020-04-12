using System;
using System.Threading.Tasks;

namespace DummyPayService.Domain
{
    public interface IBankEmitentClient
    {
        Task<PaymentTransaction> PaymentIntentionAsync(Payment payment);
        Task<PaymentTransaction> CheckPaymentAsync(Guid transactionId, string paRes);
        Task<PaymentStatuses> GetPaymentStatusAsync(Guid transactionId);
    }
}
