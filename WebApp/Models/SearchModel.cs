namespace WebApp.Models;
public class SearchModel
{
    public string ToSearch { get; set; }
    public string[] SortArgs { get; set; }

    public SearchModel()
    {
        ToSearch = "";
        SortArgs = new string[2];
    }
}