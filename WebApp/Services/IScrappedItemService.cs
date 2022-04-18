using BusinessModel.SiteData;
using BusinessModel.Representation;

namespace WebApp.Services
{
    public interface ISearchItemService
    {
        List<IRepresentableItem> FindItemByTitle(string title, Dictionary < string, bool > usedSites);
    }
}