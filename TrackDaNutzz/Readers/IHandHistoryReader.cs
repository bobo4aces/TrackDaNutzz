using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TrackDaNutzz.Readers
{
    public interface IHandHistoryReader
    {
        Task<IEnumerable<string>> ReadAsync(IFormFile file);
    }
}
