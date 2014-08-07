using System.Collections.Generic;
using System.Linq;
using DataMiner.Structures;
using HabrData.Models;
using HtmlAgilityPack;

namespace DataMiner.Parsers
{
    internal class PageParser
    {
        public static IEnumerable<Post> Parse(HtmlNode node)
        {
            return node
                .SelectNodes(".//*[@id='layout']/div[3]/div[1]/div[3]/div[1]")
                .Nodes()
                .Where(n => n.NodeType == HtmlNodeType.Element)
                .Select(n => PostParser.Parse(n))
                .ToList();
        }
    }
}
