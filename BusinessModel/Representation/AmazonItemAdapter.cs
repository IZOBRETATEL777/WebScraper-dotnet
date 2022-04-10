namespace BusinessModel.Representation;
using SiteData;

class AmazonItemAdapter : IRepresentableItem
{
    private AmazonItem item;

    public AmazonItemAdapter(AmazonItem item)
    {
        this.item = item;
    }
    public string GetShortTitle()
    {
        return item.Title.Substring(0, item.Title.Length > 50 ? 50 : item.Title.Length);
    }
    public Price GetPriceInManats()
    {
        Price convertedPrice = new Price();
        convertedPrice.Currency = "AZN";
        if (item.Price.Value != null)
        {
            convertedPrice.Value = item.Price.Value * (decimal)0.022;
        }
        return convertedPrice;
    }

    public string GetStore()
    {
        return "Amazon";
    }
}