namespace BusinessModel.Representation;
using SiteData;
using Enum;

class TrendyolItemAdapter : IRepresentableItem
{
    private TrendyolItem item;

    public TrendyolItemAdapter(TrendyolItem item)
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
            convertedPrice.Value = item.Price.Value * (decimal)0.12;
        }
        return convertedPrice;
    }

    public string GetStore()
    {
        return StoresEnum.Trendyol.GetFullName();
    }
}