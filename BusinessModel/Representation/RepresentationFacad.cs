namespace BusinessModel.Representation;
using SiteData;

public class RepresentationFacad
{
    public IRepresentableItem? Adapt(AbstractWebItem item)
    {
        if (item is AmazonItem)
        {
            return new AmazonItemAdapter((AmazonItem)item);
        }
        else if (item is TrendyolItem)
        {
            return new TrendyolItemAdapter((TrendyolItem)item);
        }
        else if (item is TapAzItem)
        {
            return new TapAzItemAdapter((TapAzItem)item);
        }
        else
        {
            return null;
        }
    }
}