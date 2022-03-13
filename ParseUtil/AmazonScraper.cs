namespace ParseUtil;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class AmazonScraper : ScraperTemplate
{
    private IWebDriver Driver;
    private string SearchingPattern;

    public AmazonScraper(string searchingPattern)
    {
        this.SearchingPattern = searchingPattern;
        this.Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("https://www.amazon.in/");

    }

    protected override void SearchItemsByPattern()
    {
        IWebElement element = Driver.FindElement(By.XPath("//*[@id='twotabsearchtextbox']"));
        element.SendKeys(this.SearchingPattern);
        element = Driver.FindElement(By.XPath("//*[@id='nav-search-submit-button']"));
        element.Click();
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

    protected override Price GetPrice(IWebElement item)
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

    protected override string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("a-text-normal")).Text;
        return title;
    }

    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}