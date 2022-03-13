using OpenQA.Selenium;
namespace ParseUtil;

using OpenQA.Selenium.Chrome;

public class TrendyolScraper : ScraperTemplate
{
    private IWebDriver Driver;
    private string SearchingPattern;

    public TrendyolScraper(string searchingPattern)
    {
        this.SearchingPattern = searchingPattern;
        this.Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("https://www.trendyol.com/az");
        Driver.Navigate().Refresh();
    }

    protected override void SearchItemsByPattern()
    {
        IWebElement element = this.Driver.FindElement(By.XPath("//*[@id='search']"));
        element.SendKeys(this.SearchingPattern);
        element = this.Driver.FindElement(By.XPath("//*[@id='tydortyuzdortpage']/div/div/div[4]/form/div/div[2]/button"));
        element.Click();
    }

    protected override List<IWebElement> ScrapItems()
    {
        List<IWebElement> items = new List<IWebElement>();

        for (int itemCount = 1; itemCount < 11; itemCount++)
        {
            try
            {
                string xPathItem = $"//*[@id='search-app']/div/div[1]/div[2]/div[3]/div/div[{itemCount}]";
                IWebElement item = this.Driver.FindElement(By.XPath(xPathItem));
                items.Add(item);
            }
            catch (Exception)
            {

            }
        }

        return items;
    }

    protected override Price GetPrice(IWebElement item)
    {

        Decimal? value = null;
        String? currency = null;
        try
        {
            string[] priceCurrency = item.FindElement(By.ClassName("prc-box-sllng")).Text.Split();
            value = Decimal.Parse(priceCurrency[0].Replace(".", ""));
            currency = priceCurrency[1];
        }
        catch (Exception)
        {
        }
        return new Price(value, currency);
    }

    protected override string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("prdct-desc-cntnr-name")).Text;
        return title;
    }

    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}