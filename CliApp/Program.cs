using BusinessModel.Scrapers;
using BusinessModel.Users;
using BusinessModel.SiteData;

Console.WriteLine("Enter item to search:");
String toSearch = Console.ReadLine() ?? throw new Exception();

Buyer[] buyers = {
    new Buyer("Jhon", "Doe", "jhon_doe@mail.az", new AmazonScraper()), 
    new Buyer("Donald", "Trump", "donald_j_trump@yande.ru", new TapAzScraper()),
    new Buyer("Jack", "Ripper", "bestSeller@gmail.com", new TrendyolScraper()),
};

foreach (Buyer buyer in buyers)
{
    List<AbstractWebItem> items = buyer.Search(toSearch);
    foreach (AbstractWebItem item in items) {
        System.Console.WriteLine($"Title: {item.Title}\nPrice: {item.Price}\n");
    }
}


