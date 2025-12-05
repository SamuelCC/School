using HtmlAgilityPack;
using School.Models;

namespace School.Services
{
    public class MsnNewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MsnNewsService> _logger;

        public MsnNewsService(HttpClient httpClient, ILogger<MsnNewsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<NewsHeadline>> GetTopHeadlinesAsync(int count = 3)
        {
            var headlines = new List<NewsHeadline>();

            try
            {
                // MSN News Taiwan URL
                var url = "https://www.msn.com/zh-tw/news";
                var html = await _httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                // Try to find news articles using various selectors
                // MSN's structure may vary, so we'll try multiple approaches
                var articleNodes = htmlDoc.DocumentNode.SelectNodes("//a[@data-title]") 
                    ?? htmlDoc.DocumentNode.SelectNodes("//article//a[@href]")
                    ?? htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'news')]//a[@href]");

                if (articleNodes != null)
                {
                    foreach (var node in articleNodes.Take(count))
                    {
                        var title = node.GetAttributeValue("data-title", "");
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            title = node.GetAttributeValue("aria-label", "");
                        }
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            title = node.InnerText.Trim();
                        }
                        
                        var href = node.GetAttributeValue("href", "");
                        
                        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(href))
                        {
                            var fullUrl = href.StartsWith("http") ? href : $"https://www.msn.com{href}";
                            
                            headlines.Add(new NewsHeadline
                            {
                                Title = System.Net.WebUtility.HtmlDecode(title),
                                Url = fullUrl,
                                Source = "MSN",
                                PublishedDate = DateTime.UtcNow
                            });

                            if (headlines.Count >= count)
                                break;
                        }
                    }
                }

                // If we couldn't get enough headlines, add some default ones
                if (headlines.Count < count)
                {
                    _logger.LogWarning("Could not fetch enough news headlines. Returning mock data.");
                    headlines = GetMockHeadlines(count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching MSN news headlines");
                // Return mock data on error
                headlines = GetMockHeadlines(count);
            }

            return headlines;
        }

        private List<NewsHeadline> GetMockHeadlines(int count)
        {
            var mockHeadlines = new List<NewsHeadline>
            {
                new NewsHeadline
                {
                    Title = "科技新聞：人工智慧發展突破新里程碑",
                    Url = "https://www.msn.com/zh-tw/news/technology",
                    Source = "MSN",
                    PublishedDate = DateTime.UtcNow
                },
                new NewsHeadline
                {
                    Title = "經濟快訊：全球股市今日表現穩定",
                    Url = "https://www.msn.com/zh-tw/news/money",
                    Source = "MSN",
                    PublishedDate = DateTime.UtcNow
                },
                new NewsHeadline
                {
                    Title = "體育新聞：國際體壇賽事精彩回顧",
                    Url = "https://www.msn.com/zh-tw/news/sports",
                    Source = "MSN",
                    PublishedDate = DateTime.UtcNow
                }
            };

            return mockHeadlines.Take(count).ToList();
        }
    }
}
