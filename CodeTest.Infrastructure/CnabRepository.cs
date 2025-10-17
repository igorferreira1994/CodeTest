using CodeTest.Domain;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CodeTest.Infrastructure
{
    public class CnabRepository : ICnabRepository
    {
        private readonly AppDbContext _context;

        public CnabRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cnab cnab)
        {
            await _context.Cnabs.AddAsync(cnab);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoreSummary>> GetByStoreAsync()
        {
            var cnabs = await _context.Cnabs.ToListAsync();

            var grouped = cnabs
                .GroupBy(c => new { c.StoreName, c.StoreOwner })
                .Select(g => new StoreSummary
                {
                    StoreName = g.Key.StoreName,
                    StoreOwner = g.Key.StoreOwner,
                    TotalBalance = g.Sum(c => GetSignedValue(c)),
                    Cnabs = g.ToList()
                }).ToList();

            return grouped;
        }

        private decimal GetSignedValue(Cnab c)
        {
            return c.Type switch
            {
                2 or 3 or 9 => -c.Value,
                _ => c.Value
            };
        }
    }


}
