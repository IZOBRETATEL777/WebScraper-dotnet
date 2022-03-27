using ParseUtil.Scrapers;
using ParseUtil.Users;
using ParseUtil.SiteData;

Console.WriteLine("Enter item to search:");
String toSearch = Console.ReadLine() ?? throw new Exception();

Buyer[] buyers = {
    new Buyer("Jhon", "Doe", "jhon_doe@mail.az", new AmazonScraper()), 
    new Buyer("Donald", "Trump", "donald_j_trump@yande.ru", new TapAzScraper()),
    new Buyer("Jack", "Ripper", "bestSeller@gmail.com", new TrendyolScraper()),
};

foreach (Buyer buyer in buyers)
{
    List<IItem> items = buyer.Search(toSearch);
    foreach (IItem item in items) {
        System.Console.WriteLine($"Title: {item.Title}\nPrice: {item.Price}\n");
    }
}


