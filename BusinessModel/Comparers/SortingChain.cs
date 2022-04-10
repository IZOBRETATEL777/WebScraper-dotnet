namespace BusinessModel.Comparers;
using SiteData;

public class SortingChain
{
    List<AbstractWebItem> Items;
    ComporatorFascade ComparerFascade;

    public SortingChain(List<AbstractWebItem> items)
    {
        this.Items = items;
        this.ComparerFascade = new ComporatorFascade();
    }
    public SortingChain ContinueSorting(string parameter) {
        Items.Sort(ComparerFascade.GetComparator(parameter));
        return this;
    }

    public List<AbstractWebItem> FinishSorting() {
        return this.Items;
    }
    
}