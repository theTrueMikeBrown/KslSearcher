using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KslSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.ksl.com/?nid=231&sid=74268&cat=&search=cargo+bike&zip=84093&distance=&min_price=&max_price=&type=&category=184&subcat=&sold=0&city=&addisplay=&sort=5&userid=&markettype=sale&adsstate=&nocache=1&o_facetSelected=&o_facetKey=&o_facetVal=&viewSelect=list&viewNumResults=12&sort=5";
            var target = "<div class=\"adBox\">";
            var account = "thefakemikebrown@gmail.com";
            var password = "TODO";
            var targetAccount = "TheTrueMikeBrown@gmail.com";
            var config = new SearcherSenderConfig
            {
                SearchUrl = url,
                SearchTarget = target,
                EmailAccount = account,
                Password = password,
                TargetAccount = targetAccount,
                FilterFile = @"C:\Temp\bikeSearcher\bikes.txt"
            };

            var searcherSender = new SearcherSender(config);
            searcherSender.SearchAndSend();
        }
    }
}
