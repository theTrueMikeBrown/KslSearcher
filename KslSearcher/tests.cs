using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KslSearcher
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void WHEN_results_found_then_return_true()
        {
            var url = "http://www.ksl.com/?nid=231&sid=74268&cat=&search=bucket+bike&zip=84093&distance=&min_price=&max_price=&type=&category=184&subcat=&sold=&city=&addisplay=&sort=5&userid=&markettype=sale&adsstate=&nocache=1&o_facetSelected=&o_facetKey=&o_facetVal=&viewSelect=list&viewNumResults=12&sort=5";
            var target = "<div class=\"adBox\">";
            var searcher = new Searcher();
            var result = searcher.Search(url, target);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void WHEN_results_not_found_return_false()
        {
            var url = "http://www.ksl.com/?nid=231&sid=74268&cat=&search=bucket+bike&zip=84093&distance=&min_price=&max_price=&type=&category=184&subcat=&sold=0&city=&addisplay=&sort=5&userid=&markettype=sale&adsstate=&nocache=1&o_facetSelected=&o_facetKey=&o_facetVal=&viewSelect=list&viewNumResults=12&sort=5";
            var target = "<div class=\"adBox\">";
            var searcher = new Searcher();
            var result = searcher.Search(url, target);
            Assert.AreEqual(1, result.Count);
        }

        [Ignore]
        [Test]
        public void WHEN_send_email_THEN_actually_sends()
        {
            Sender sender = new Sender(
                "thefakemikebrown@gmail.com",
                "thefakemikebrown@gmail.com",
                "TODO: at runtime replace this with my real password");
            sender.SendEmail("TheTrueMikeBrown@gmail.com", "TestEmail", "TestEmail");
        }

        [Test]
        public void WHEN_searcherSenderRuns_THEN_doesnt_send_when_nothing()
        {
            var url = "http://www.ksl.com/?nid=231&sid=74268&cat=&search=bucket+bike&zip=84093&distance=&min_price=&max_price=&type=&category=184&subcat=&sold=0&city=&addisplay=&sort=5&userid=&markettype=sale&adsstate=&nocache=1&o_facetSelected=&o_facetKey=&o_facetVal=&viewSelect=list&viewNumResults=12&sort=5";
            var target = "<div class=\"adBox\">";
            var account = "thefakemikebrown@gmail.com";
            var password = "TODO: at runtime replace this with my real password";
            var targetAccount = "TheTrueMikeBrown@gmail.com";
            var config = new SearcherSenderConfig
            {
                SearchUrl = url,
                SearchTarget = target,
                EmailAccount = account,
                Password = password,
                TargetAccount = targetAccount,
                FilterFile = @"C:\Temp\bikes.txt"
            };

            var searcherSender = new SearcherSender(config);
            searcherSender.SearchAndSend();
        }
        [Test]
        public void WHEN_searcherSenderRuns_THEN_sends_when_something()
        {
            var url = "http://www.ksl.com/?nid=231&sid=74268&cat=&search=bucket+bike&zip=84093&distance=&min_price=&max_price=&type=&category=184&subcat=&sold=&city=&addisplay=&sort=5&userid=&markettype=sale&adsstate=&nocache=1&o_facetSelected=&o_facetKey=&o_facetVal=&viewSelect=list&viewNumResults=12&sort=5";
            var target = "<div class=\"adBox\">";
            var account = "thefakemikebrown@gmail.com";
            var password = "TODO: at runtime replace this with my real password";
            var targetAccount = "TheTrueMikeBrown@gmail.com";
            var config = new SearcherSenderConfig
            {
                SearchUrl = url,
                SearchTarget = target,
                EmailAccount = account,
                Password = password,
                TargetAccount = targetAccount,
                FilterFile = @"C:\Temp\bikes.txt"
            };

            var searcherSender = new SearcherSender(config);
            searcherSender.SearchAndSend();
        }
    }
}
