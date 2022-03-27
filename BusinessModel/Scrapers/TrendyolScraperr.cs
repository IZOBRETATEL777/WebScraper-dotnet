namespace BusinessModel.Scrapers;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using SiteData;

public class TrendyolScraper : ScraperTemplate, IScrapable
{
    private IWebDriver Driver;

    public TrendyolScraper()
    {
        this.Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("https://www.trendyol.com/az");
        Driver.Navigate().Refresh();
    }

    public override void SearchItemsByPattern(string pattern)
    {
        IWebElement element;
        try
        {
            element = this.Driver.FindElement(By.XPath("//*[@id='search']"));
            element.SendKeys(pattern);
            element = this.Driver.FindElement(By.XPath("//*[@id='tydortyuzdortpage']/div/div/div[4]/form/div/div[2]/button"));
            element.Click();
            
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot create search query on Trendyol.com!");
        }
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

    public Price GetPrice(IWebElement item)
    {

        Decimal? value = null;
        String? currency = null;
        try
        {
            string[] priceCurrency = item.FindElement(By.ClassName("prc-box-dscntd")).Text.Split();
            value = Decimal.Parse(priceCurrency[0].Replace(".", ""));
            currency = priceCurrency[1];
        }
        catch (Exception)
        {
        }
        return new Price(value, currency);
    }

    public string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("prdct-desc-cntnr-name")).Text;
        return title;
    }

    protected override TrendyolItem ConvertToItem(IWebElement webElement)
    {
        return new TrendyolItem(
            "trendyol",
            GetTitle(webElement),
            GetPrice(webElement)
        );
    }

    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}
