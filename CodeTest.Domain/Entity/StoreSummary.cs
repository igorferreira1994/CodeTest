using System.Transactions;

namespace CodeTest.Domain
{
    public class StoreSummary
    {
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
        public decimal TotalBalance { get; set; }
        public List<Cnab> Cnabs { get; set; } = new();
    }
}