using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TrackDaNutzz.Readers
{
    public class HandHistoryReader : IHandHistoryReader
    {
        public async Task<IEnumerable<string>> ReadAsync(IFormFile file)
        {
            ConcurrentQueue<string> result = new ConcurrentQueue<string>();
            using (StreamReader stream = new StreamReader(file.OpenReadStream()))
            {
                while (!stream.EndOfStream)
                {
                    string line = await stream.ReadLineAsync();
                    result.Enqueue(line.Trim());
                }
            }
            return result;
        }
    }
}
