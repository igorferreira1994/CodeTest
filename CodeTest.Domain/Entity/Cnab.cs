
namespace CodeTest.Domain
{
    public class Cnab
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public TimeSpan Time { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }
    }
}
