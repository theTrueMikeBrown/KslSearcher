using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace KslSearcher
{
    public class Filterer
    {
        private IEnumerable<string> _file;

        public Filterer(string filterFile)
        {
            _file = File.ReadAllLines(filterFile);
        }

        public bool Filter(Searcher.SearchResult arg)
        {
            return !_file.Contains(arg.Url);
        }

        public void AddToFilter(IEnumerable<string> newValues)
        {
             _file = _file.Union(newValues);
        }

        public void SaveFilter(string filterFile)
        {
            File.WriteAllLines(filterFile, _file);
        }
    }
}