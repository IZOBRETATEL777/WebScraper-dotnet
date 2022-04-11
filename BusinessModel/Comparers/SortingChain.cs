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
        this.Items = this.Items.OrderBy(x => x, this.ComparerFascade.GetComparator(parameter)).ToList();
        return this;
    }

    public List<IRepresentableItem> FinishSorting() {
        return this.Items;
    }
    
}
