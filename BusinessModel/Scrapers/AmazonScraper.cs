namespace BusinessModel.Scrapers;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using SiteData;

public class AmazonScraper : ScraperTemplate
{
    private IWebDriver Driver;

    public AmazonScraper()
    {
        this.Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("https://www.amazon.in/");

    }

    public override void SearchItemsByPattern(string pattern)
    {
        IWebElement element;
        try
        {
            element = Driver.FindElement(By.XPath("//*[@id='twotabsearchtextbox']"));
            element.SendKeys(pattern);
            element = Driver.FindElement(By.XPath("//*[@id='nav-search-submit-button']"));
            element.Click();
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot create search query on Amazon.com!");
        }
   }

    protected override List<IWebElement> ScrapItems()
    {
        List<IWebElement> items = new List<IWebElement>();

        for (int itemCount = 2; itemCount < 12; itemCount++)
        {
            try
            {
                string xPathItem = $"//*[@id='search']/div[1]/div[1]/div/span[3]/div[2]/div[{itemCount}]/div/div/div/div/div";
                IWebElement item = this.Driver.FindElement(By.XPath(xPathItem));
                items.Add(item);
            }
            catch (Exception)
            {

            }
        }

        return items;
    }

    protected Price GetPrice(IWebElement item)
    {

        Price price = new Price();
        try
        {
            price.Value = Decimal.Parse(item.FindElement(By.ClassName("a-price-whole")).Text);
            price.Currency = item.FindElement(By.ClassName("a-price-symbol")).Text;
        }
        catch (Exception)
        {
        }
        return price;
    }

    protected string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("a-text-normal")).Text;
        return title;
    }
    protected override AmazonItem ConvertToItem(IWebElement webElement)
    {
        return new AmazonItem(
            "amazon",
            GetTitle(webElement),
            GetPrice(webElement)
        );
    }
    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}
