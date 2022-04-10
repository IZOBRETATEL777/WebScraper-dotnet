namespace BusinessModel.Comparers;

using System.Collections.Generic;
using SiteData;

public class DescendingPriceComparer : IComparer<AbstractWebItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 AbstractWebItem classes in asceending order.
    public int Compare(AbstractWebItem? x,
                       AbstractWebItem? y)
    {   if (x == null || (x.Price == null) && (y == null || y.Price == null))
            return 0;
        if (x == null || x.Price == null)
            return -1;
        if (y == null || y.Price == null)
            return 1;
        // return 0 if prices are equal
        if (x.Price.Value == y.Price.Value)
            return 0;
        
        // return 1 if x is less than y
        if (x.Price.Value < y.Price.Value)
            return 1;
        
        // return -1 if y is less than x
        return -1;
    }
}