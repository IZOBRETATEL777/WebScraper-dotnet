namespace BusinessModel.Comparers;

using System.Collections.Generic;
using Representation;

public class DescendingPriceComparer : IComparer<IRepresentableItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 IRepresentableItem classes in asceending order.
    public int Compare(IRepresentableItem? x,
                       IRepresentableItem? y)
    {   if (x == null || (x.GetPriceInManats() == null) && (y == null || y.GetPriceInManats() == null))
            return 0;
        if (x == null || x.GetPriceInManats() == null)
            return -1;
        if (y == null || y.GetPriceInManats() == null)
            return 1;
        // return 0 if prices are equal
        if (x.GetPriceInManats().Value == y.GetPriceInManats().Value)
            return 0;
        
        // return 1 if x is less than y
        if (x.GetPriceInManats().Value < y.GetPriceInManats().Value)
            return 1;
        
        // return -1 if y is less than x
        return -1;
    }
}