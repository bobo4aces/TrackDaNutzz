using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
