namespace BusinessModel.Comparers;
using SiteData;
public class ComporatorFascade
{
    public IComparer<AbstractWebItem> GetComparator(string name)
    {
        switch (name)
        {
            case "alp-asc":
                return new AscendingAlphabetComparer();
            case "desc-alp":
                return new DescendingAlphabetComparer();
            case "asc-price":
                return new AscendingPriceComparer();
            case "desc-price":
                return new DescendingPriceComparer();
            default:
                return new AscendingPriceComparer();
        }
    }
}