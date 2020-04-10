using System;
using System.Runtime.Serialization;

namespace DummyPayService.Api.DataContracts
{
    [DataContract]
    public class ConfirmPaymentRequestParameter
    {
        [DataMember]
        public Guid TransactionId { get; set; }
        public string PaRes { get; set; }
    }
}
