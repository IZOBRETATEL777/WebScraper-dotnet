namespace ParseUtil;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class TapAzScraper : ScraperTemplate
{
    private IWebDriver Driver;

    public TapAzScraper()
    {
        this.Driver = new ChromeDriver();
        this.Driver.Navigate().GoToUrl("https://tap.az/");
    }

    public override void SearchItemsByPattern(string pattern)
    {
        IWebElement element = this.Driver.FindElement(By.XPath("//*[@id='q_keywords']"));
        element.SendKeys(pattern);
        element = this.Driver.FindElement(By.ClassName("header-btn_search"));
        element.Click();
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

    protected override Price GetPrice(IWebElement item)
    {
        Price price = new Price();
        try
        {
            price.Value = Decimal.Parse(item.FindElement(By.ClassName("price-val")).Text.Replace(" ", ""));
            price.Currency = item.FindElement(By.ClassName("price-cur")).Text;
        }
        catch (Exception)
        {
        }
        return price;
    }

    protected override string GetTitle(IWebElement item)
    {
        string title = item.FindElement(By.ClassName("products-name")).Text;
        return title;
    }

    protected override void FinishScraping()
    {
        this.Driver.Quit();
    }
}
