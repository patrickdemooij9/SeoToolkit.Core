using System;
using System.Collections.Generic;
using SeoToolkit.Core.Interfaces.SiteCrawler;

namespace SeoToolkit.Core.Common.SiteCrawler
{
    public class DefaultScheduler : IScheduler
    {
        private readonly Queue<Uri> _pagesToCrawl;
        private readonly List<Uri> _pagesCrawled;

        public int Count => _pagesToCrawl.Count;

        public DefaultScheduler()
        {
            _pagesToCrawl = new Queue<Uri>();
            _pagesCrawled = new List<Uri>();
        }

        public void Add(Uri pageToCrawl)
        {
            _pagesToCrawl.Enqueue(pageToCrawl);
            if (!IsUriKnown(pageToCrawl))
                _pagesCrawled.Add(pageToCrawl);
        }

        public void Add(IEnumerable<Uri> pagesToCrawl)
        {
            foreach (var page in pagesToCrawl)
                Add(page);
        }

        public void AddKnownUri(Uri uri)
        {
            if (!_pagesCrawled.Contains(uri))
                _pagesCrawled.Add(uri);
        }

        public Uri GetNext()
        {
            return _pagesToCrawl.Dequeue();
        }

        public bool IsUriKnown(Uri uri)
        {
            return _pagesCrawled.Contains(uri);
        }
    }
}
