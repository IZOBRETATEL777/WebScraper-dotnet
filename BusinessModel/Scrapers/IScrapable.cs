namespace BusinessModel.Scrapers;

using OpenQA.Selenium;

using SiteData;
public interface IScrapable
{
    string GetTitle(IWebElement webElement);
    Price GetPrice(IWebElement webElement);
}