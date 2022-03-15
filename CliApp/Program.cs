using ParseUtil;

Console.WriteLine("Enter item to search:");
String toSearch = Console.ReadLine() ?? throw new Exception();

User[] users = {
    new User("Jhon", "Doe", "jhon_doe@mail.az", new AmazonScraper()), 
    new User("Donald", "Trump", "donald_j_trump@yande.ru", new TapAzScraper()),
    new User("Jack", "Ripper", "bestSeller@gmail.com", new TrendyolScraper()),
};

foreach (User user in users)
{
    List<IItem> items = user.Search(toSearch);
    foreach (IItem item in items) {
        System.Console.WriteLine($"Title: {item.Title}\nPrice: {item.Price}\n");
    }
}


