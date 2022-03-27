namespace BusinessModel.SiteData;

public class StandardItem: IItem
{
    public string Title { get; set; }
    public Price Price { get; set; }

    public StandardItem(string title, Price price)
    {
        this.Price = price;
        this.Title = title;
    }
}
