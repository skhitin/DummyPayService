using DummyPayService.Core.DataContracts;
using DummyPayService.Domain;
using System;

namespace DummyPayService.Core.Extrensions
{
    public static class CreatePaymentRequestParameterExtensions
    {
        public static Payment ToPayment(this CreatePaymentRequestParameter requestParameter)
        {
            return new Payment
            {
                OrderId = requestParameter.OrderId,
                Amount = requestParameter.Amount,
                Currency = requestParameter.Currency,
                Country = requestParameter.Country,
                Card = requestParameter.ToCard()
            };
        }

        public static Card ToCard(this CreatePaymentRequestParameter requestParameter)
        {
            if (!int.TryParse(requestParameter.CardExpiryDate, out var expirationDate))
                throw new ArgumentException("The card expiration date is not valid.");

            if (!int.TryParse(requestParameter.CVV, out var cvv))
                throw new ArgumentException("The cvv code is not valid.");

            return new Card
            {
                Number = requestParameter.CardNumber,
                Holder = requestParameter.CardHolder,
                ExpiryDate = expirationDate,
                Cvv = cvv
            };
        }
    }
}
