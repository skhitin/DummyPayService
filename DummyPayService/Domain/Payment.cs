using System;

namespace DummyPayService.Domain
{
    public class Payment
    {
        public Guid OrderId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public Card Card { get; set; }
    }
}
