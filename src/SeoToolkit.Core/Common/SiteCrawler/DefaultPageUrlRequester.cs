using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SeoToolkit.Core.Interfaces.SiteCrawler;
using SeoToolkit.Core.Models.SiteCrawler;

namespace SeoToolkit.Core.Common.SiteCrawler
{
    public class DefaultPageUrlRequester : IPageRequester
    {
        private readonly HttpClient _httpClient;

        public DefaultPageUrlRequester()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CrawledPageModel> MakeRequest(Uri uri)
        {
            if (uri is null)
                throw new ArgumentNullException(nameof(uri));

            var crawledPage = new CrawledPageModel(uri);
            HttpResponseMessage response = null;
            try
            {
                crawledPage.RequestStarted = DateTime.Now;
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    response = await _httpClient.SendAsync(requestMessage, CancellationToken.None).ConfigureAwait(false);
                }
                var statusCode = Convert.ToInt32(response.StatusCode);
                crawledPage.StatusCode = statusCode;
            }
            catch (HttpRequestException ex)
            {
                //TODO: Log error?
            }
            catch (TaskCanceledException ex)
            {
                //TODO: Log error?
            }
            catch (Exception ex)
            {
                //TODO: Log error?
            }
            finally
            {
                crawledPage.RequestCompleted = DateTime.Now;
                try
                {
                    if (response != null)
                    {
                        var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                        var htmlDocument = new HtmlDocument();
                        htmlDocument.Load(contentStream, Encoding.UTF8);
                        crawledPage.Content = htmlDocument;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error?
                }
            }
            return crawledPage;
        }
    }
}
