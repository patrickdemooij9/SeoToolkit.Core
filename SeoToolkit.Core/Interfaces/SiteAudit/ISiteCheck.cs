using System;
using System.Collections.Generic;
using SeoToolkit.Core.Models.SiteAudit;
using SeoToolkit.Core.Models.SiteCrawler;

namespace SeoToolkit.Core.Interfaces.SiteAudit
{
    public interface ISiteCheck
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }

        IEnumerable<PageCrawlResult> RunCheck(CrawledPageModel page);
        string FormatMessage(PageCrawlResult crawlResult);
        bool Compare(PageCrawlResult result, PageCrawlResult otherResult);
    }
}
