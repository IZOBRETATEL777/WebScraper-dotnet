namespace BusinessModel.Representation;
using SiteData;

class TrendyolItemAdapter : IRepresentableItem
{
    private TrendyolItem item;

    public TrendyolItemAdapter(TrendyolItem item)
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
            convertedPrice.Value = item.Price.Value * (decimal)0.12;
        }
        return convertedPrice;
    }
}