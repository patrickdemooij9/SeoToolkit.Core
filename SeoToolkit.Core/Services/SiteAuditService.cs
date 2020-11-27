using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeoToolkit.Core.Interfaces.SiteAudit;
using SeoToolkit.Core.Interfaces.SiteCrawler;
using SeoToolkit.Core.Models.EventArgs;
using SeoToolkit.Core.Models.SiteAudit;

namespace SeoToolkit.Core.Services
{
    public class SiteAuditService
    {
        private readonly ISiteAuditRepository _siteAuditRepository;
        private readonly ISiteCrawler _siteCrawler;

        private SiteAuditDto _currentSiteAudit;

        public SiteAuditService(ISiteAuditRepository siteAuditRepository, ISiteCrawler siteCrawler)
        {
            _siteAuditRepository = siteAuditRepository;
            _siteCrawler = siteCrawler;
        }

        public async Task<SiteAuditDto> StartSiteAudit(SiteAuditDto model)
        {
            _currentSiteAudit = model;

            //TODO: Use a delegate here as this won't work with multiple requests now
            _siteCrawler.OnPageCrawlCompleted += HandleChecks;
            await _siteCrawler.Crawl(model.StartingUrl, model.MaxPagesCrawled ?? int.MaxValue);
            _siteCrawler.OnPageCrawlCompleted -= HandleChecks;
            return model;
        }

        public void Save(SiteAuditDto model)
        {
            if (model.Id == 0)
                _siteAuditRepository.Add(model);
            else
                _siteAuditRepository.Update(model);
        }

        public SiteAuditDto Get(int id) => _siteAuditRepository.Get(id);
        public IEnumerable<SiteAuditDto> GetAll() => _siteAuditRepository.GetAll();
        public void Delete(int id) => _siteAuditRepository.Delete(id);

        private void HandleChecks(object sender, PageCrawlCompleteArgs args)
        {
            _currentSiteAudit.AddCrawledPageWithResults(new CrawledPageDto
            {
                PageUrl = args.Page.Url
            }, _currentSiteAudit.SiteChecks?.SelectMany(it => it.RunCheck(args.Page)).ToList());
            Save(_currentSiteAudit);
        }
    }
}
