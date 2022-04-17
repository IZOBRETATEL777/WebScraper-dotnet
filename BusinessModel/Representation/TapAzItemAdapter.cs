namespace BusinessModel.Representation;
using SiteData;
using Enum;

class TapAzItemAdapter : IRepresentableItem
{
    private TapAzItem item;

    public TapAzItemAdapter(TapAzItem item)
    {
        this.item = item;
    }
    public string GetShortTitle()
    {
        return item.Title.Substring(0, item.Title.Length > 50 ? 50 : item.Title.Length);
    }
    public Price GetPriceInManats()
    {
        return item.Price;
    }

    public string GetStore()
    {
        return StoresEnum.Tapaz.GetFullName();
    }
}