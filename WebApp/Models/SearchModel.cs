namespace WebApp.Models;
using  BusinessModel.Enum;
public class SearchModel
{
    public string ToSearch { get; set; }
    public Dictionary < string, bool > UsedSites { get; set; }


    public SearchModel()
    {
        ToSearch = "";
        UsedSites = new Dictionary<string, bool>();
        foreach (var storeName in Enum.GetNames(typeof(StoresEnum)))
        {
            UsedSites.Add(storeName, false);
        }
    }
}