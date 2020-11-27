using System;
using System.Linq;
using System.Threading.Tasks;
using SeoToolkit.Core.Interfaces.SiteCrawler;
using SeoToolkit.Core.Models.EventArgs;
using SeoToolkit.Core.Models.SiteCrawler;

namespace SeoToolkit.Core.Common.SiteCrawler
{
    public class SiteCrawler : ISiteCrawler
    {
        private readonly IPageRequester _pageRequester;
        private readonly IScheduler _scheduler;
        private readonly ILinkParser _linkParser;

        public event EventHandler<PageCrawlCompleteArgs> OnPageCrawlCompleted;

        public SiteCrawler(
            IPageRequester pageRequester,
            IScheduler scheduler,
            ILinkParser linkParser)
        {
            _pageRequester = pageRequester ?? new DefaultPageUrlRequester();
            _scheduler = scheduler ?? new DefaultScheduler();
            _linkParser = linkParser ?? new DefaultLinkParser();
        }

        public async Task Crawl(Uri startingUrl, int maxUrlsToCrawl)
        {
            var maxCrawls = maxUrlsToCrawl;
            var currentCrawls = 0;
            var crawlComplete = false;

            _scheduler.Add(startingUrl);

            while (!crawlComplete && currentCrawls < maxCrawls)
            {
                var linksLeftToSchedule = _scheduler.Count;
                if (linksLeftToSchedule > 0)
                {
                    var linkToCrawl = _scheduler.GetNext();
                    ProcessPage(await _pageRequester.MakeRequest(linkToCrawl));
                    currentCrawls++;
                }
                else
                {
                    //Finished the crawl
                    crawlComplete = true;
                }
            }
        }

        private void ProcessPage(CrawledPageModel page)
        {
            var links = _linkParser.GetLinks(page).ToArray();
            page.FoundUrls = links;
            foreach (var link in links)
            {
                if (!_scheduler.IsUriKnown(link) && page.Url.Authority == link.Authority)
                {
                    _scheduler.Add(link);
                }
            }
            _scheduler.AddKnownUri(page.Url);
            OnPageCrawlCompleted?.Invoke(this, new PageCrawlCompleteArgs() { Page = page });
        }
    }
}
