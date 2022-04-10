namespace WebApp.Services;
using BusinessModel.SiteData;
using BusinessModel.Comparers;

public class ResutlSortingServiceImpl : IResutlSorting
{
    public List<AbstractWebItem> ApplySorting(List<AbstractWebItem> items, string[] args)
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