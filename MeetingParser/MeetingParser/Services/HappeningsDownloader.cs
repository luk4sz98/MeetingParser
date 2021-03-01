using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using MeetingParser.Entities;
using MeetingParser.Interfaces;

namespace MeetingParser.Services
{
    public class HappeningsDownloader : IHappeningsDownloader
    {
        private string URL;
        private readonly HtmlWeb _web;

        public HappeningsDownloader()
        {
            _web = new HtmlWeb();
        }

        public void ConstructURL(string city, string target)
        {
            URL = $@"https://crossweb.pl/wydarzenia/{city}/{target}/";
        }

        public List<Happening> GetFromWeb()
        {
            var happenings = new List<Happening>();

            var htmlDoc = _web.Load(URL);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//a[@class='clearfix']");

            foreach (var htmlNode in nodes)
            {
                var date = ReplaceWhitespaces(htmlNode.SelectSingleNode(".//div[@class='num fl']")) + "." + DateTime.Now.Year;
                var place = ReplaceWhitespaces(htmlNode.SelectSingleNode(".//div[@class='colTab city']"));
                var title = ReplaceWhitespaces(htmlNode.SelectSingleNode(".//div[@class='colTab title']"));
                var isPaid = ReplaceWhitespaces(htmlNode.SelectSingleNode(".//div[@class='colTab cost']"));
                var type = ReplaceWhitespaces(htmlNode.SelectSingleNode(".//div[@class='colTab type']"));

                happenings.Add(new Happening(date: DateTime.Parse(date), place: place, title: title, isPaid: isPaid, type: type));
            }

            return happenings;
        }

        private string ReplaceWhitespaces(HtmlNode singleNode)
        {
            return Regex.Replace(singleNode.InnerText.Trim(), @"\s+", " ");
        }
    }
}
