namespace BusinessModel.Representation;
using SiteData;

class TapAzItemAdapter : IRepresentableItem
{
    private TapAzItem item;

    public TapAzItemAdapter(TapAzItem item)
    {
        this.item = item;
    }
    public string getShortTitle()
    {
        return item.Title.Substring(0, item.Title.Length > 10 ? 10 : item.Title.Length);
    }
    public Price getPriceInManats()
    {
        return item.Price;
    }
}