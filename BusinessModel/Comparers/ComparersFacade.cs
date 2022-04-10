namespace BusinessModel.Comparers;
using Representation;

public class ComporatorFascade
{
    public IComparer<IRepresentableItem> GetComparator(string name)
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