using System;
using System.Collections.Generic;
using SeoToolkit.Core.Models.SiteCrawler;

namespace SeoToolkit.Core.Interfaces.SiteCrawler
{
    public interface ILinkParser
    {
        IEnumerable<Uri> GetLinks(CrawledPageModel page);
    }
}
