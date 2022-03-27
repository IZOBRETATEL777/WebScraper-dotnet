namespace BusinessModel.Scrapers;

using OpenQA.Selenium;

using SiteData;

public abstract class ScraperTemplate
{
    public List<AbstractWebItem> GetItems()
    {
        List<AbstractWebItem> items = new List<AbstractWebItem>();
        List<IWebElement> scrapedItems = this.ScrapItems();
        foreach (IWebElement webElement in scrapedItems)
        {
            items.Add(ConvertToItem(webElement));
        }
        this.FinishScraping();
        return items;
    }
    public abstract void SearchItemsByPattern(string pattern);
    protected abstract List<IWebElement> ScrapItems();
    protected abstract AbstractWebItem ConvertToItem(IWebElement item);
    protected abstract void FinishScraping();
}
