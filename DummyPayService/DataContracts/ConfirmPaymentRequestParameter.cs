using System;
using System.Runtime.Serialization;

namespace DummyPayService.DataContracts
{
    [DataContract]
    public class ConfirmPaymentRequestParameter
    {
        [DataMember]
        public Guid TransactionId { get; set; }
        public string PaRes { get; set; }
    }
}
