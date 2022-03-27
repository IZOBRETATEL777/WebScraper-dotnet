namespace BusinessModel.SiteData;

public abstract class AbstractWebItem
{
    public string ItemType { get; }
    public string Title { get; set; }
    public Price Price { get; set; }

    public AbstractWebItem(string itemType, string title, Price price) {
        this.ItemType = itemType;
        this.Title = title;
        this.Price = price;
    }
}
