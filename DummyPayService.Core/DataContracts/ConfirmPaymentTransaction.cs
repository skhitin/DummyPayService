using DummyPayService.Domain;
using System;
using System.Runtime.Serialization;

namespace DummyPayService.Core.DataContracts
{
    [DataContract]
    public class ConfirmPaymentTransaction
    {
        [DataMember]
        public Guid TransactionId { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public Guid OrderId { get; set; }

        [DataMember]
        public string LastFourDigits { get; set; }
    }
}
