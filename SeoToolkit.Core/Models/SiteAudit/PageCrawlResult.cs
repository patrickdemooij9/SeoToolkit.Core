using System.Collections.Generic;
using SeoToolkit.Core.Enums;
using SeoToolkit.Core.Interfaces.SiteAudit;

namespace SeoToolkit.Core.Models.SiteAudit
{
    public class PageCrawlResult
    {
        public ISiteCheck Check { get; set; }
        public SiteCrawlResultType Result { get; set; }
        public Dictionary<string, string> ExtraValues { get; set; }
    }
}
