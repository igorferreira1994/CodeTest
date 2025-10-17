using CodeTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Application.Service
{
    public interface ICnabService
    {
        Task<List<StoreSummary>> GetStoreSummariesAsync();
        Task ProcessCnabFileAsync(Stream fileStream);
    }

}
