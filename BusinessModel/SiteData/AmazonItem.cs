namespace BusinessModel.SiteData;

public class AmazonItem : AbstractWebItem {
    public AmazonItem(string itemType, string title, IPrice price) : base(itemType, title, price)
    {

    }
}