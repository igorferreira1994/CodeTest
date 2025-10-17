namespace CodeTest.Domain
{
    public interface ICnabRepository
    {
        Task AddAsync(Cnab Cnab);
        Task<List<StoreSummary>> GetByStoreAsync();
    }
}
