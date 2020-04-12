namespace DummyPayService.Domain
{
    public enum PaymentStatuses
    {
        Init,
        Pending,
        Approved,
        Declined,
        DeclinedDueToInvalidCreditCard
    }
}
