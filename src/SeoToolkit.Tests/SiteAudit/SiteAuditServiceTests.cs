using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SeoToolkit.Core.Interfaces.SiteAudit;
using SeoToolkit.Core.Interfaces.SiteCrawler;
using SeoToolkit.Core.Models.SiteAudit;
using SeoToolkit.Core.Services;

namespace SeoToolkit.Tests.SiteAudit
{
    [TestClass]
    public class SiteAuditServiceTests
    {
        [TestMethod]
        public void TestCreatingNewSiteAudit()
        {
            var repositoryMock = new Mock<ISiteAuditRepository>();
            var siteCrawlerMock = new Mock<ISiteCrawler>();
            var siteAuditService = new SiteAuditService(repositoryMock.Object, siteCrawlerMock.Object);

            siteAuditService.Save(new SiteAuditDto { Id = 0 });

            repositoryMock.Verify(it => it.Add(It.IsAny<SiteAuditDto>()));
        }

        [TestMethod]
        public void TestUpdatingSiteAudit()
        {
            var repositoryMock = new Mock<ISiteAuditRepository>();
            var siteCrawlerMock = new Mock<ISiteCrawler>();
            var siteAuditService = new SiteAuditService(repositoryMock.Object, siteCrawlerMock.Object);

            siteAuditService.Save(new SiteAuditDto { Id = 1 });

            repositoryMock.Verify(it => it.Update(It.IsAny<SiteAuditDto>()));
        }
    }
}
