namespace BusinessModel.Users;

using Scrapers;
using SiteData;

public class Buyer: User
{
    private ScraperTemplate Scraper;

    public Buyer(string name, string surname, string email, ScraperTemplate scraper) : base(name, surname, email)
    {
        this.Scraper = scraper;
    }

    public List<IItem> Search(string toSearch)
    {
        this.Scraper.SearchItemsByPattern(toSearch);
        return this.Scraper.GetItems();
    }

    public void UpdateScraper(ScraperTemplate scraper)
    {
        this.Scraper = scraper;
    }
}
