using ParseUtil;

Console.WriteLine("Enter item to search:");
String toSearch = Console.ReadLine() ?? throw new Exception();

ScraperTemplate[] scrapers = {new AmazonScraper(toSearch), new TapAzScraper(toSearch), new TrendyolScraper(toSearch)};

List<Item> items = new List<Item>();

foreach (ScraperTemplate scraper in scrapers){
    items.AddRange(scraper.GetItems());
}

foreach (Item item in items) {
    System.Console.WriteLine($"Title: {item.Title}\nPrice: {item.Price}\n");
}



