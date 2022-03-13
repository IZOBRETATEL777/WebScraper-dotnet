namespace ParseUtil;

public class Item
{
    public string Title { get; set; }
    public Price Price { get; set; }

    public Item(string title, Price price)
    {
        this.Price = price;
        this.Title = title;
    }
}