namespace ParseUtil;
using OpenQA.Selenium;

public abstract class ScraperTemplate
{
    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        List<IWebElement> scrapedItems = this.ScrapItems();
        foreach (IWebElement webItem in scrapedItems)
        {
            string title = this.GetTitle(webItem);
            Price price = this.GetPrice(webItem);
            items.Add(new Item(title, price));
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
