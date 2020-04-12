using System;

namespace DummyPayService.Domain
{
    public class PaymentTransaction
    {
        public Guid TransactionId { get; set; }

        public PaymentStatuses TransactionStatus { get; set; }

        public Payment Payment { get; set; }

        public string PaReq { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }
    }
}
