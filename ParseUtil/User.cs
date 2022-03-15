namespace ParseUtil;

public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public ScraperTemplate Scraper;

    public User (string name, string surname, string email, ScraperTemplate scraper)
    {
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
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
