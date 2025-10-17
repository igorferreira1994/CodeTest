using CodeTest.Domain;

namespace CodeTest.Application.Service
{
    public class CnabService : ICnabService
    {
        private readonly ICnabRepository _repository;
        private readonly ICnabParser _parser;

        public CnabService(ICnabRepository repository, ICnabParser parser)
        {
            _repository = repository;
            _parser = parser;
        }

        public async Task ProcessCnabFileAsync(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var transaction = _parser.Parse(line);
                await _repository.AddAsync(transaction);
            }
        }

        public async Task<List<StoreSummary>> GetStoreSummariesAsync()
        {
            return await _repository.GetByStoreAsync();
        }
    }


}
