using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataMiner.Domain;
using DataMiner.Helpers;
using DataMiner.Structures;
using HtmlAgilityPack;

namespace DataMiner.Parsers
{
    internal class PostParser
    {
        static Regex dateRx = new Regex(@"\d\d\d\d");
        private const string today = "сегодня";
        private const string yesterday = "вчера";


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
            if (date.StartsWith(today))
                date = date.Replace(today + " в", DateTime.Now.ToShortDateString());
            else if (date.StartsWith(yesterday))
                date = date.Replace(yesterday + " в", DateTime.Now.Subtract(TimeSpan.FromDays(1)).ToShortDateString());
            else if (!dateRx.IsMatch(date))
                date = date.Replace("в ", "2014 ");
            else
                date = date.Replace("в ", "");
            return Convert.ToDateTime(date);
        }
    }
}
