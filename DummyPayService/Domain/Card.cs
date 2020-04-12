namespace DummyPayService.Domain
{
    public class Card
    {
        public string Number { get; set; }
        public string Holder { get; set; }
        public int ExpiryDate { get; set; }
        public int Cvv { get; set; }
    }
}
