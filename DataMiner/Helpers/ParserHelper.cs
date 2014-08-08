using System.Text.RegularExpressions;

namespace DataMiner.Helpers
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
