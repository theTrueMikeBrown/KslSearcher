using System.Linq;

namespace KslSearcher
{
    public class SearcherSender
    {
        private readonly SearcherSenderConfig _config;
        private Searcher _searcher;
        private Filterer _filterer;
        private Sender _sender;

        public SearcherSender(SearcherSenderConfig config)
        {
            _config = config;
            _searcher = new Searcher();
            _sender = new Sender(config.EmailAccount, config.EmailAccount, config.Password);
            _filterer = new Filterer(config.FilterFile);
        }

        public void SearchAndSend()
        {
            var results = _searcher
                .Search(_config.SearchUrl, _config.SearchTarget)
                .Where(_filterer.Filter)
                .ToList();
            if (results.Count > 0)
            {
                _sender.SendEmail(_config.TargetAccount,
                    "Thing(s) Found", 
                    string.Join("\r\n<br/>", results.Select(r => 
                      $"<div><h2><a href=\"http://www.ksl.com/{r.Url}\">{r.Title}</a></h2><em>{r.Description}</em>&mdash;<span>{r.Price}</span></div>"
                    )));
                _filterer.AddToFilter(results.Select(result => result.Url));
                _filterer.SaveFilter(_config.FilterFile);
            }
        }
    }
}