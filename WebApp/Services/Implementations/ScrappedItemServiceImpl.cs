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
        public List<IRepresentableItem> FindItemByTitle(string title, Dictionary < string, bool > usedSites)
        {
            List<IRepresentableItem>items = new List<IRepresentableItem>();
            RepresentationFacad representationFacad = new RepresentationFacad();
            List<ScraperTemplate> scrapers = new List<ScraperTemplate>();
            if (usedSites["amazon"])
            {
                scrapers.Add(new AmazonScraper());
            }
            if (usedSites["tapaz"])
            {
                scrapers.Add(new TapAzScraper());
            }
            if (usedSites["trendyol"])
            {
                scrapers.Add(new TrendyolScraper());
            }
            foreach (ScraperTemplate scraperTemplate in scrapers)
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