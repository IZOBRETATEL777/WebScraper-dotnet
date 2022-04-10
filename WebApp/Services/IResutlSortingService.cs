namespace WebApp.Services;
using BusinessModel.SiteData;

public interface IResutlSorting
{
    List<AbstractWebItem> ApplySorting(List<AbstractWebItem> items, string[] args);
}
