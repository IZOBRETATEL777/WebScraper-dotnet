namespace BusinessModel.Comparers;

using System.Collections.Generic;
using SiteData;

public class AscendingAlphabetComparer : IComparer<AbstractWebItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 AbstractWebItem classes in asceending order.
    public int Compare(AbstractWebItem? x,
                       AbstractWebItem? y)
    {   if (x == null || (x.Title == null) && (y == null || y.Title == null))
            return 0;
        if (x == null || x.Title == null)
            return -1;
        if (y == null || y.Title == null)
            return 1;
        // return 0 if prices are equal
        if (string.Compare(x.Title, y.Title) == 0)
            return 0;
        
        // return 1 if x is more than y
        if (string.Compare(x.Title, y.Title) > 0)
            return 1;
        
        // return -1 if y is more than x
        return -1;
    }
}