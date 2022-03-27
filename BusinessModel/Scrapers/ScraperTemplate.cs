namespace BusinessModel.Scrapers;

using OpenQA.Selenium;

using SiteData;

public abstract class ScraperTemplate
{
    public List<IItem> GetItems()
    {
        List<IItem> items = new List<IItem>();
        List<IWebElement> scrapedItems = this.ScrapItems();
        foreach (IWebElement webItem in scrapedItems)
        {
            string title = this.GetTitle(webItem);
            Price price = this.GetPrice(webItem);
            items.Add(new StandardItem(title, price));
        }
        this.FinishScraping();
        return items;
    }
    public abstract void SearchItemsByPattern(string pattern);
    protected abstract List<IWebElement> ScrapItems();
    protected abstract Price GetPrice(IWebElement item);
    protected abstract string GetTitle(IWebElement item);
    protected abstract void FinishScraping();
}
