namespace BusinessModel.Comparers;

using System.Collections.Generic;
using Representation;

public class DescendingAlphabetComparer : IComparer<IRepresentableItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 IRepresentableItem classes in asceending order.
    public int Compare(IRepresentableItem? x,
                       IRepresentableItem? y)
    {   if (x == null || (x.GetShortTitle() == null) && (y == null || y.GetShortTitle() == null))
            return 0;
        if (x == null || x.GetShortTitle() == null)
            return -1;
        if (y == null || y.GetShortTitle() == null)
            return 1;
        // return 0 if prices are equal
        if (string.Compare(x.GetShortTitle(), y.GetShortTitle()) == 0)
            return 0;
        
        // return 1 if x is less than y
        if (string.Compare(x.GetShortTitle(), y.GetShortTitle()) < 0)
            return 1;
        
        // return -1 if y is less than x
        return -1;
    }
}