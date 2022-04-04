namespace BusinessModel.Scrapers;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using SiteData;

public class TapAzScraper : ScraperTemplate
{
    private IWebDriver Driver;
    private PriceFactory factory = new ConcretePriceFactory();

    public TapAzScraper()
    {
        this.Driver = new ChromeDriver();
        this.Driver.Navigate().GoToUrl("https://tap.az/");
    }

    public override void SearchItemsByPattern(string pattern)
    {
        IWebElement element;
        try
        {
            element = this.Driver.FindElement(By.XPath("//*[@id='q_keywords']"));
            element.SendKeys(pattern);
            element = this.Driver.FindElement(By.ClassName("header-btn_search"));
            element.Click();
        }
        catch
        {
            Console.WriteLine("Cannot create search query on Tap.az!");
        }
    }

    protected override List<IWebElement> ScrapItems()
    {
        List<IWebElement> items = new List<IWebElement>();

        for (int itemCount = 1; itemCount < 11; itemCount++)
        {
            try
            {
                string xPathItem = $"//*[@id='content']/div/div/div[3]/div[2]/div[{itemCount}]";
                IWebElement item = Driver.FindElement(By.XPath(xPathItem));
                items.Add(item);
            }
            catch (Exception)
            {

            }
        }

        return items;
    }

    protected IPrice GetPrice(IWebElement item)
    {
        Decimal Value = 0;
        String Currency = "USD";
        try
        {
            Value = Decimal.Parse(item.FindElement(By.ClassName("price-val")).Text.Replace(" ", ""));
            Currency = item.FindElement(By.ClassName("price-cur")).Text;
        }
        catch (Exception)
        {
        }
        IPrice price = factory.GetCurrency(Value, Currency);
        Console.WriteLine("Price: " + price.Value);

        return price;
    }

    protected string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("products-name")).Text;
        return title;
    }

    protected override TapAzItem ConvertToItem(IWebElement webElement)
    {
        return new TapAzItem(
            "tapaz",
            GetTitle(webElement),
            GetPrice(webElement)
        );
    }

    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}
