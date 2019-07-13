using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.BindingModels;

namespace TrackDaNutzz.Parsers
{
    public interface IParser
    {
        void ParseHandHistory(IEnumerable<string> handHistory);
    }
}
