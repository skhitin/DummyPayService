using System.Runtime.Serialization;

namespace DummyPayService.Core.DataContracts
{
    [DataContract]
    public class TResult<T>
    {
        [DataMember]
        public T Result { get; set; }
    }
}
