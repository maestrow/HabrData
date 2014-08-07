using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataMiner
{
    public class Miner
    {
        public void GetData()
        {
            string content = getUrl(Urls.GetPageUrl(1));
        }

        private string getUrl(string url)
        {
            HttpWebRequest req = WebRequest.CreateHttp(url);
            req.Method = "GET";
            WebResponse res = req.GetResponse();
            var stream = new StreamReader(res.GetResponseStream());
            return stream.ReadToEnd();
        }
    }
}
