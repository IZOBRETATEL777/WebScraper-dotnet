namespace BusinessModel.Comparers;
using Representation;

public class SortingChain
{
    List<IRepresentableItem> Items;
    ComporatorFascade ComparerFascade;

    public SortingChain(List<IRepresentableItem> items)
    {
        this.Items = items;
        this.ComparerFascade = new ComporatorFascade();
    }
    public SortingChain ContinueSorting(string parameter) {
        Items.Sort(ComparerFascade.GetComparator(parameter));
        return this;
    }

    public List<IRepresentableItem> FinishSorting() {
        return this.Items;
    }
    
}