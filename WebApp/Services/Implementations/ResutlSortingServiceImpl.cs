namespace WebApp.Services;
using BusinessModel.Representation;
using BusinessModel.Comparers;

public class ResutlSortingServiceImpl : IResutlSorting
{
    public List<IRepresentableItem> ApplySorting(List<IRepresentableItem> items, string[] args)
    {
        SortingChain sortingChain = new SortingChain(items);
        foreach (string arg in args)
        {
            if (arg != null)
            {
                sortingChain = sortingChain.ContinueSorting(arg);
            }
        }
        return sortingChain.FinishSorting();
    }

}