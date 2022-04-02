namespace BusinessModel.Comparers;

using System;
using System.Collections.Generic;
using SiteData;

public class PriceComparer : IComparer<AbstractWebItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 AbstractWebItem classes in asceending order.
    public int Compare(AbstractWebItem x,
                       AbstractWebItem y)
    {   
        // return 0 if prices are equal
        if (x.Price.Value == y.Price.Value)
            return 0;
        
        // return 1 if x is more than y
        if (x.Price.Value > y.Price.Value)
            return 1;
        
        // return -1 if y is more than x
        return -1;
    }
}