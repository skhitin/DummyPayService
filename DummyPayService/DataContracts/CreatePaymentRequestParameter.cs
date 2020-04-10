using System;
using System.Runtime.Serialization;

namespace DummyPayService.Api.DataContracts
{
    [DataContract]
    public class CreatePaymentRequestParameter
    {
        [DataMember]
        public Guid OrderId { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string CardNumber { get; set; }

        [DataMember]
        public string CardHolder { get; set; }

        [DataMember]
        public string CardExpirationDate { get; set; }

        [DataMember]
        public string CVV { get; set; }
    }
}
