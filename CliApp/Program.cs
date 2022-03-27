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
List<AbstractWebItem> webItems = new List<AbstractWebItem>();
foreach (Buyer buyer in buyers)
    webItems.AddRange(buyer.Search(toSearch));

foreach (AbstractWebItem item in webItems)
{
    switch (item.GetItemType())
    {
        case "amazon":
            AmazonItem amazonItem = (AmazonItem)item;
            System.Console.WriteLine($"Title: {amazonItem.Title}\nPrice: {amazonItem.Price}\n");
            break;
        case "tapaz":
            TapAzItem tapAzItem = (TapAzItem)item;
            System.Console.WriteLine($"Title: {tapAzItem.Title}\nPrice: {tapAzItem.Price}\n");
            break;
        case "trendyol":
            TrendyolItem trendyolItem = (TrendyolItem)item;
            System.Console.WriteLine($"Title: {trendyolItem.Title}\nPrice: {trendyolItem.Price}\n");
            break;
        default:
            System.Console.WriteLine("Unknown type");
            break;
    }
}
