namespace WebApp.Models;
public class SearchModel
{
    public string ToSearch { get; set; }

    public SearchModel()
    {
        ToSearch = "";
    }

    public SearchModel(string toSearch)
    {
        this.ToSearch = toSearch;
    }
}