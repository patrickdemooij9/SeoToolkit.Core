using System;
using System.Collections.Generic;

namespace SeoToolkit.Core.Models.SiteAudit
{
    public class CrawledPageDto
    {
        public CrawledPageDto ParentPage { get; set; }
        public Uri PageUrl { get; set; }
        public List<PageCrawlResult> Results { get; }

        public CrawledPageDto()
        {
            Results = new List<PageCrawlResult>();
        }
    }
}
