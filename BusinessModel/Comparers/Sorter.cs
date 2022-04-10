namespace BusinessModel.Comparers;
using SiteData;

public class Sorter
{
    List<AbstractWebItem> Items;
    ComporatorFascade ComparerFascade;

    public Sorter(List<AbstractWebItem> items)
    {
        this.Items = items;
        this.ComparerFascade = new ComporatorFascade();
    }
    public Sorter ContinueSorting(string parameter) {
        Items.Sort(ComparerFascade.GetComparator(parameter));
        return this;
    }

    public List<AbstractWebItem> FinishSorting() {
        return this.Items;
    }
    
}