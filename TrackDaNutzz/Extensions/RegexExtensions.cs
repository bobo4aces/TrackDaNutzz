using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrackDaNutzz.Extensions
{
    public static class RegexExtensions
    {
        public static Dictionary<string, string> GetGroups(this string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException($"Invalid regex pattern - string: \"{input}\" does not match pattern: {pattern}");
            }
            string[] groupNames = regex.GetGroupNames()
                .Where(n=>n.Length > 1)
                .ToArray();
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var groupName in groupNames)
            {
                Group group = match.Groups[groupName];
                if (!result.ContainsKey(group.Name))
                {
                    result.Add(group.Name, group.Value);
                }
                else
                {
                    throw new InvalidOperationException("Duplicated regex group");
                }
            }
            return result;
        }
        public static bool IsValid(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
