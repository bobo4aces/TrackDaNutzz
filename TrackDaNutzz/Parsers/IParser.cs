using System.Collections.Generic;

namespace TrackDaNutzz.Parsers
{
    public interface IParser
    {
        int ParseHandHistory(IEnumerable<string> handHistory);
    }
}
