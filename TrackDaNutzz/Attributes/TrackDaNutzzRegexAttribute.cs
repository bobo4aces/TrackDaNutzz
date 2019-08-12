using System;

namespace TrackDaNutzz.Attributes
{
    public class TrackDaNutzzRegexAttribute : Attribute
    {
        private readonly string pattern;
        public TrackDaNutzzRegexAttribute(string pattern)
        {
            this.pattern = pattern;
        }


    }
}
