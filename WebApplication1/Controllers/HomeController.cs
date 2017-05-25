using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngleSharp.Parser.Html;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string query)
        {
            HomePageViewModel vm = new HomePageViewModel();
            vm.Query = query;
            if (!String.IsNullOrEmpty(query))
            {
                vm.Items = new AmazonSearcher().SearchAmazon(query);
            }
            return View(vm);
        }
    }

    public class AmazonItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ASIN { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }

    public class HomePageViewModel
    {
        public IEnumerable<AmazonItem> Items { get; set; }
        public string Query { get; set; }
    }

    public class AmazonSearcher
    {
        public IEnumerable<AmazonItem> SearchAmazon(string query)
        {
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "HELLO!!";
                string html = client.DownloadString("https://www.amazon.com/s?field-keywords=" + query);
                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var lis = document.QuerySelectorAll("li.s-result-item");
                List<AmazonItem> result = new List<AmazonItem>();
                foreach (var li in lis)
                {
                    if (li.Attributes.Any(a => a.Name == "hidden"))
                    {
                        continue;
                    }
                    AmazonItem item = new AmazonItem();
                    item.Title = li.QuerySelector("h2").TextContent;
                    item.Image = li.QuerySelector("img").GetAttribute("src");
                    var price = li.QuerySelector(".sx-price-large");
                    if (price != null)
                    {
                        item.Price = price.TextContent.Replace("\n", "").Replace("\r\n", "");
                    }
                    item.Url = li.QuerySelector(".a-link-normal").GetAttribute("href");
                    item.ASIN = li.GetAttribute("data-asin");
                    result.Add(item);
                    //Console.WriteLine(li.QuerySelector("h2").TextContent);
                    //Console.WriteLine(li.QuerySelector("img").GetAttribute("src"));
                    //Console.WriteLine(li.QuerySelector(".sx-price-whole").TextContent);
                    //Console.WriteLine(li.QuerySelector(".a-link-normal").GetAttribute("href"));
                    //Console.WriteLine(li.GetAttribute("data-asin"));
                }
                


                return result;
            }
        }
    }
}