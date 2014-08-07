using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMiner.Structures
{
    internal class ParserHelper
    {
        public static string IdFromHref(string href)
        {
            var rx = new Regex(@"/(\w+)/$");
            var match = rx.Match(href);
            return match.Groups[1].Value;
        }
    }
}
