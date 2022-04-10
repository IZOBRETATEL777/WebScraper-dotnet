using BusinessModel.SiteData;
using BusinessModel.Scrapers;

namespace WebApp.Services
{
    public class SearchItemServiceImpl : ISearchItemService
    {
        public SearchItemServiceImpl()
        {
        }
        public List<AbstractWebItem> FindItemByTitle(string title)
        {
            List<AbstractWebItem>Items = new List<AbstractWebItem>();
            ScraperTemplate[] scraper = {new AmazonScraper()};//, new TapAzScraper(), new TrendyolScraper()};
            foreach (ScraperTemplate scraperTemplate in scraper)
            {
                scraperTemplate.SearchItemsByPattern(title);
                Items.AddRange(scraperTemplate.GetItems());
            }
            return Items;
        }
    }
}