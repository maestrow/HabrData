using System;
using System.Collections.Generic;
using System.Linq;
using DataMiner.Structures;
using HabrData.Models;
using HtmlAgilityPack;

namespace DataMiner.Parsers
{
    internal class PostParser
    {
        public static Post Parse(HtmlNode node)
        {
            Post post = new Post();

            post.PublicationDate = getPublished(node.SelectNodes("*[@class='published']")[0].InnerText);
            post.Title = node.SelectNodes("*[@class='title']/a")[0].InnerText;
            post.Id = int.Parse(ParserHelper.IdFromHref(node.SelectNodes("*[@class='title']/a")[0].Attributes["href"].Value));
            post.Hubs = getHubs(node);
            post.Excerpt = node.SelectNodes("*[@class='content html_format']")[0].InnerText;

            return post;
        }

        private static string getHubs(HtmlNode node)
        {
            return node.SelectNodes("*[@class='hubs']").Nodes()
                .Where(n => n.NodeType == HtmlNodeType.Element && n.Name == "a")
                .Select(n => ParserHelper.IdFromHref(n.Attributes["href"].Value))
                .Aggregate((a, b) => string.Format("{0}, {1}", a, b));
        }

        private static DateTime? getPublished(string date)
        {
            DateTime? result = null;
            try
            {
                result = Convert.ToDateTime(date.Replace("в ", ""));
            }
            catch (FormatException)
            {
            }
            return result;
        }
    }
}
