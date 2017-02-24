using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace FerretCrawl
{
    class Program
    {
        static void Main()
        {
            // Create web client
            using (WebClient client = new WebClient())
            {
                // Set user agent.
                client.Headers["User-Agent"] =
                    "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
                    //"Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    //"(compatible; MSIE 6.0; Windows NT 5.1; " +
                    //".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                // Accept-encoding headers.
                client.Headers["Accept-Encoding"] = "gzip";

                // Download data.
                byte[] arr = client.DownloadData("http://www.mosinu.com/");

                // Get response header.
                string contentEncoding = client.ResponseHeaders["Content-Encoding"];

                // Write values.
                Console.WriteLine("--- WebClient result ---");
                Console.WriteLine(arr.Length);
            }
        }
    }
}
