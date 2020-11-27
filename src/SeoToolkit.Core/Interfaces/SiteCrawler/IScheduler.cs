using System;
using System.Collections.Generic;

namespace SeoToolkit.Core.Interfaces.SiteCrawler
{
    public interface IScheduler
    {
        int Count { get; }
        void Add(Uri pageToCrawl);
        void Add(IEnumerable<Uri> pagesToCrawl);
        Uri GetNext();
        void AddKnownUri(Uri uri);
        bool IsUriKnown(Uri uri);
    }
}
