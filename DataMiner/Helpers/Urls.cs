using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiner
{
    internal static class Urls
    {
        const string _site = "http://habrahabr.ru/";
        const string _post = "post/{0}/";
        const string _page = "posts/top/alltime/page{0}/";

        public static string GetPostUrl(int id)
        {
            return _site + string.Format(_post, id);
        }

        public static string GetPageUrl(int number)
        {
            return _site + string.Format(_page, number);
        }
    }
}
