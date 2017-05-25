using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace ConsoleApplication87
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                #region go away
                //string html = client.DownloadString("http://www.lakewoodprogramming.com/skin/default.css");
                //Console.WriteLine(html);


                //client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //string result = client.UploadString("http://localhost:50073/home/add",
                //    "firstName=from&lastName=console app&age=100");

                //Console.WriteLine(result);
                //client.Headers["User-Agent"] = "HELLO!!";
                //string code = "console.log('hello world');";
                //string html = client.UploadString("http://pasted.co/index.php?act=submit",
                //    "subdomain=&antispam=1&website=&paste_title=asdf&input_text=asdfasdf&timestamp=1c28e012c856f8b43f6603a318de8634&paste_password=&code=1");
                //Console.WriteLine(html);
                #endregion

                //string html = client.DownloadString("http://www.lakewoodprogramming.com");


                //var parser = new HtmlParser();
                //var document = parser.Parse(html);
                //var scheduleSection = document.GetElementById("section-schedule");
                //Console.WriteLine(scheduleSection.TextContent);

                client.Headers[HttpRequestHeader.UserAgent] = "JET IS BETTER!!!";
                //string query = "macbook";
                //string html = client.DownloadString("https://www.amazon.com/s?field-keywords=" + query);
                //var parser = new HtmlParser();
                //var document = parser.Parse(html);
                //var lis = document.QuerySelectorAll("li.s-result-item");
                //foreach (var li in lis)
                //{
                //    //Console.WriteLine(li.QuerySelector("h2").TextContent);
                //    //Console.WriteLine(li.QuerySelector("img").GetAttribute("src"));
                //    //Console.WriteLine(li.QuerySelector(".sx-price-whole").TextContent);
                //    //Console.WriteLine(li.QuerySelector(".a-link-normal").GetAttribute("href"));
                //    Console.WriteLine(li.GetAttribute("data-asin"));
                //}


                string html = client.DownloadString("http://thelakewoodscoop.com");
                var parser = new HtmlParser();
                var document = parser.Parse(html);
                foreach (var post in document.QuerySelectorAll(".post"))
                {
                    var img = post.QuerySelector("img");
                    if (img != null)
                    {
                        //client.DownloadFile(img.GetAttribute("src"), Guid.NewGuid().ToString() + ".jpg");
                        Console.WriteLine(img.GetAttribute("src"));
                    }
                }

                Console.WriteLine("Done");
                Console.ReadKey(true);

            }
        }
    }
}
