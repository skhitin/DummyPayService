using System;
using System.Runtime.Serialization;

namespace DummyPayService.Core.DataContracts
{
    [DataContract]
    public class ConfirmPaymentRequestParameter
    {
        [DataMember]
        public Guid TransactionId { get; set; }

        [DataMember]
        public string PaRes { get; set; }
    }
}
