namespace BusinessModel.SiteData;

public abstract class AbstractWebItem
{
    private string ItemType;
    public string Title { get; set; }
    public IPrice Price { get; set; }

    public AbstractWebItem(string itemType, string title, IPrice price) {
        this.ItemType = itemType;
        this.Title = title;
        this.Price = price;
    }

    public string GetItemType()
    {
        return this.ItemType;
    }
}
