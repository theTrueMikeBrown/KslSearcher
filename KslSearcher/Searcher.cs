using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace KslSearcher
{
    public class Searcher
    {
        public List<SearchResult> Search(string url, string target)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = string.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            var splits = html.Split(new[] { target }, StringSplitOptions.None);
            
            var result = new List<SearchResult>();
            for (int i = 1; i < splits.Length; i++)
            {
                result.Add(new SearchResult(splits[i]));
            }
            return result;
        }

        public class SearchResult
        {
            public SearchResult(string s)
            {
                var titleMatches = Regex.Matches(s, "<a class=\"listlink\" [^>]*>([^<]*)<\\/a>");
                Title = titleMatches[0].Groups[1].Value;

                var urlMatches = Regex.Matches(s, "<a class=\"listlink\" href=\"([^\"]*)\">");
                Url = urlMatches[0].Groups[1].Value;

                var descriptionMatches = Regex.Matches(s, "<div class=\"adDesc\">([^<]*)<");
                Description = descriptionMatches[0].Groups[1].Value.Replace("&nbsp;", "").Trim();

                var priceMatches = Regex.Matches(s, "<div class=\"priceBox\">(?:.*?\\s*?)*<span[^>]*>([^<]*)<");
                Price = priceMatches[0].Groups[1].Value;
            }

            public string Title { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
        }
    }
}