using System;
using System.Threading.Tasks;
using SeoToolkit.Core.Models.EventArgs;

namespace SeoToolkit.Core.Interfaces.SiteCrawler
{
    public interface ISiteCrawler
    {
        event EventHandler<PageCrawlCompleteArgs> OnPageCrawlCompleted;

        Task Crawl(Uri startingUrl, int maxUrlsToCrawl);
    }
}
