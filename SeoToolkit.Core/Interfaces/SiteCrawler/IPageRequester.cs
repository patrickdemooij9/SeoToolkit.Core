using System;
using System.Threading.Tasks;
using SeoToolkit.Core.Models.SiteCrawler;

namespace SeoToolkit.Core.Interfaces.SiteCrawler
{
    public interface IPageRequester
    {
        Task<CrawledPageModel> MakeRequest(Uri uri);
    }
}
