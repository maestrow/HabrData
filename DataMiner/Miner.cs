using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataMiner.Domain;
using DataMiner.Helpers;
using DataMiner.Parsers;
using HtmlAgilityPack;

namespace DataMiner
{
    public class Miner
    {
        HabrDataContext db = new HabrDataContext();

        public void LoadPages(PostType type)
        {
            var postList = Enumerable.Range(1, 100)
                .Select(i => Urls.GetPageUrl(type, i))
                .Select(url => getContent(url))
                .Select(content => PageParser.Parse(getDocNode(content)))
                .SelectMany(posts => posts.Select(post => post))
                .Select(post => post);

            foreach (Post post in postList)
            {
                save(type, post);
            }
        }

        private string getContent(string url)
        {
            System.Diagnostics.Debug.WriteLine(url);
            HttpWebRequest req = WebRequest.CreateHttp(url);
            req.Method = "GET";
            WebResponse res = req.GetResponse();
            var stream = new StreamReader(res.GetResponseStream());
            return stream.ReadToEnd();
        }

        private HtmlNode getDocNode(string content)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            return doc.DocumentNode;
        }

        private void save(PostType type, Post post)
        {
            post.PostType = type;
            db.Posts.AddOrUpdate(post);
            db.SaveChanges();
        }
    }
}
