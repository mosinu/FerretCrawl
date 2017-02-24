using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace FerretCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintDisclaimer();

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
                client.Headers["Accept-Encoding"] = "html";
                client.Headers["Accept-Encoding"] = "text";

                // Download data.
                byte[] arr = client.DownloadData("http://blog.mosinu.com/");
                string sTr = client.DownloadString("http://blog.mosinu.com/");

                // Get response header.
                string contentEncoding = client.ResponseHeaders["Content-Encoding"];

                // Write values.
                //Console.WriteLine("--- WebClient result ---");
                PrintRedAttentionText(" *** Ferret result *** ");
                foreach (LinkItem i in LinkFinder.Find(sTr))
                {
                    Console.WriteLine(arr.Length);
                    client.DownloadDataAsync(i);
                    //Debug.WriteLine(i);
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
        }

        // Add a disclaimer
        private static void PrintDisclaimer()
        {
            PrintAttentionText("Ferret");
        }

        // Set console color to yellow
        private static void PrintAttentionText(string text)
        {
            ConsoleColor originalColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = originalColor;
        }

        // Set console color to red
        private static void PrintRedAttentionText(string text)
        {
            ConsoleColor originalColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = originalColor;
        }
    }
}
