using DummyPayService.Domain;
using System;
using System.Runtime.Serialization;

namespace DummyPayService.Core.DataContracts
{
    [DataContract]
    public class PaymentTransaction
    {
        [DataMember]
        public Guid TransactionId { get; set; }

        [DataMember]
        public string TransactionStatus { get; set; }

        [DataMember]
        public string PaReq { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Method { get; set; }
    }
}
