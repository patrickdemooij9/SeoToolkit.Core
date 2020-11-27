using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeoToolkit.Core.Common.SiteCrawler;
using System;

namespace SeoToolkit.Tests.SiteCrawler
{
    [TestClass]
    public class DefaultSchedulerTests
    {
        [TestMethod]
        public void TestAddingSingleNewPage()
        {
            var scheduler = new DefaultScheduler();
            var url = new Uri("http://google.nl");

            scheduler.Add(url);
            var result = scheduler.GetNext();

            Assert.AreEqual(url, result);
        }

        [TestMethod]
        public void TestAddingMultipleNewPages()
        {
            var scheduler = new DefaultScheduler();
            var urls = new[] { new Uri("https://google.nl"), new Uri("https://google123.nl") };

            scheduler.Add(urls);
            var total = scheduler.Count;

            Assert.AreEqual(urls.Length, total);
        }

        [TestMethod]
        public void TestForAddingExistingPage()
        {
            var scheduler = new DefaultScheduler();
            var url = new Uri("https://google.nl");

            scheduler.Add(url);
            scheduler.Add(url);
            var total = scheduler.Count;

            Assert.AreEqual(1, total);
        }

        [TestMethod]
        public void TestForAddingExistingPageAfterCrawled()
        {
            var scheduler = new DefaultScheduler();
            var url = new Uri("https://google.nl");

            scheduler.AddKnownUri(url);
            scheduler.Add(url);
            var total = scheduler.Count;

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void TestCountOnlyReturningPagesToCrawl()
        {
            var scheduler = new DefaultScheduler();
            var firstUrl = new Uri("https://google.nl");
            var secondUrl = new Uri("https://gogle123.nl");

            scheduler.Add(firstUrl);
            scheduler.AddKnownUri(secondUrl);
            var total = scheduler.Count;

            Assert.AreEqual(1, total);
        }
    }
}
