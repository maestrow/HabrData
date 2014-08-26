using System;
using System.Collections.Generic;
using System.Linq;
using DataMiner.Domain;
using HtmlAgilityPack;

namespace DataMiner.Parsers
{
    internal class PageParser
    {
        private const string xpath = ".//div[@id='layout']/div[@class='inner']/div[@class='content_left']/div[@class='posts_list']/div[@class='posts shortcuts_items']";

        public static IEnumerable<Post> Parse(HtmlNode node)
        {
            return node
                .SelectNodes(xpath)
                .Nodes()
                .Where(n => n.NodeType == HtmlNodeType.Element)
                .Select(PostParser.Parse);

            //var nodes = node.SelectNodes(xpath).Nodes().Where(n => n.NodeType == HtmlNodeType.Element);

            //foreach (HtmlNode n in nodes)
            //{
            //    PostParser.Parse(n);
            //}

            //return new List<Post>();
        }
    }
}
