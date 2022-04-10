using BusinessModel.SiteData;
using BusinessModel.Scrapers;
using BusinessModel.Representation;

namespace WebApp.Services
{
    public class SearchItemServiceImpl : ISearchItemService
    {
        public SearchItemServiceImpl()
        {
        }
        public List<IRepresentableItem> FindItemByTitle(string title)
        {
            List<IRepresentableItem>items = new List<IRepresentableItem>();
            RepresentationFacad representationFacad = new RepresentationFacad();
            ScraperTemplate[] scraper = {new AmazonScraper(), new TapAzScraper(), new TrendyolScraper()};
            foreach (ScraperTemplate scraperTemplate in scraper)
            {
                scraperTemplate.SearchItemsByPattern(title);
                foreach (AbstractWebItem item in scraperTemplate.GetItems())
                {
                    IRepresentableItem? representableItem = representationFacad.Adapt(item);
                    if (representableItem != null)
                    {
                        items.Add(representableItem);
                    }
                }
            }
            return items;
        }
    }
}