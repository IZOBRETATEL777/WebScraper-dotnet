using BusinessModel.SiteData;

namespace WebApp.Services
{
    public interface ISearchItemService
    {
        List<AbstractWebItem> FindItemByTitle(string title);
    }
}