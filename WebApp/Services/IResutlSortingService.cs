namespace WebApp.Services;
using BusinessModel.SiteData;
using BusinessModel.Representation;

public interface IResutlSorting
{
    List<IRepresentableItem> ApplySorting(List<IRepresentableItem> items, string[] args);
}
