namespace BusinessModel.Representation;
using SiteData;

public interface IRepresentableItem
{
    string getShortTitle();
    Price getPriceInManats();
}
