namespace BusinessModel.Representation;
using SiteData;

class AmazonItemAdapter : IRepresentableItem
{
    private AmazonItem item;

    public AmazonItemAdapter(AmazonItem item)
    {
        this.item = item;
    }
    public string getShortTitle()
    {
        return item.Title.Substring(0, item.Title.Length > 10 ? 10 : item.Title.Length);
    }
    public Price getPriceInManats()
    {
        Price convertedPrice = new Price();
        convertedPrice.Currency = "AZN";
        if (item.Price.Value != null)
        {
            convertedPrice.Value = item.Price.Value * (decimal)0.022;
        }
        return convertedPrice;
    }
}