using RSS_Module.Interfaces;
using RSS_Module.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RSS_Module.Services
{
    /// <summary>
    /// Loading RSS feeds from supplied URL
    /// </summary>
    public class RssService : IWEBReaderService<Feed>
    {
        public IList<Feed> GetLatest(string url)
        {
            var rssFeed = XDocument.Load(url);

            var feeds = (from item in rssFeed.Descendants("item")
                         select new Feed()
                         {
                             Title = item.Element("title").Value,
                             Description = item.Element("description").Value
                         }).Take(10).ToList<Feed>();
            return feeds;
        }
    }
}