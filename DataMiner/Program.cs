using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiner.Domain;
using DataMiner.Parsers;
using HtmlAgilityPack;

namespace DataMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new Miner();
            miner.LoadPages(PostType.Monthly);

            //ParseTestPage();
            Console.WriteLine("ok");
            Console.ReadLine();
        }

        private static void ParseTestPage()
        {
            var content = File.ReadAllText("../../TestPage.html");

            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            IEnumerable<Post> result = PageParser.Parse(doc.DocumentNode);

            foreach (Post post in result)
            {
                Console.WriteLine(string.Format("{0} : {1} : {2}\n{3}\n{4}\n\n", post.Id, post.Hubs, post.PublicationDate, post.Title, post.Excerpt));
            }
        }

        private static void DrawProgressBar(int complete, int maxVal, int barSize, char progressCharacter)
        {
            Console.CursorVisible = false;
            int left = Console.CursorLeft;
            decimal perc = (decimal)complete / (decimal)maxVal;
            int chars = (int)Math.Floor(perc / ((decimal)1 / (decimal)barSize));
            string p1 = String.Empty, p2 = String.Empty;

            for (int i = 0; i < chars; i++) p1 += progressCharacter;
            for (int i = 0; i < barSize - chars; i++) p2 += progressCharacter;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(p1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(p2);

            Console.ResetColor();
            Console.Write(" {0}%", (perc * 100).ToString("N2"));
            Console.CursorLeft = left;
        }
    }
}
