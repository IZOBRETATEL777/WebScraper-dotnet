namespace BusinessModel.Representation;
using SiteData;

public interface IRepresentableItem
{
    string GetShortTitle();
    Price GetPriceInManats();

    string GetStore();
}
