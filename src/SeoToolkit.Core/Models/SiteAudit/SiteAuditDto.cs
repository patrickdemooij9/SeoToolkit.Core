using System;
using System.Collections.Generic;
using System.Linq;
using SeoToolkit.Core.Interfaces;
using SeoToolkit.Core.Interfaces.SiteAudit;

namespace SeoToolkit.Core.Models.SiteAudit
{
    public class SiteAuditDto : IEntityWithIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri StartingUrl { get; set; }
        public int? MaxPagesCrawled { get; set; }
        public List<ISiteCheck> SiteChecks { get; set; }
        public List<CrawledPageDto> CrawledPages { get; set; }

        public SiteAuditDto()
        {
            SiteChecks = new List<ISiteCheck>();
            CrawledPages = new List<CrawledPageDto>();
        }

        public void AddCrawledPageWithResults(CrawledPageDto crawledPage, List<PageCrawlResult> results)
        {
            var page = GetByUri(crawledPage.PageUrl);
            if (page is null)
            {
                CrawledPages.Add(crawledPage);
                page = crawledPage;
            }
            page.Results.AddRange(results);
        }

        public CrawledPageDto GetByUri(Uri uri)
        {
            return CrawledPages.FirstOrDefault(it => it.PageUrl == uri);
        }
    }
}
