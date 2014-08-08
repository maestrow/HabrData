using DataMiner.Domain;

namespace DataMiner.Helpers
{
    internal static class Urls
    {
        const string _site = "http://habrahabr.ru/";
        const string _post = "post/{0}/";
        const string _page = "posts/top/{0}/page{1}/";

        public static string GetPostUrl(int id)
        {
            return _site + string.Format(_post, id);
        }

        public static string GetPageUrl(PostType type, int number)
        {
            return _site + string.Format(_page, type.ToString().ToLower(), number);
        }
    }
}
