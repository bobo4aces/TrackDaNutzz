using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrackDaNutzz.Readers
{
    public interface IHandHistoryReader
    {
        Task<IEnumerable<string>> ReadAsync(IFormFile file);
    }
}
