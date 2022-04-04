namespace BusinessModel.Comparers;

using System;
using System.Collections.Generic;
using SiteData;

public class PriceComparer : IComparer<AbstractWebItem>
{
    // Custom comparator function used in sorting of Scrapped Items.
    // Compares 2 AbstractWebItem classes in asceending order.
    public int Compare(AbstractWebItem? x,
                       AbstractWebItem? y)
    {   
        Double? xPrice = x.Price.getCommonPrice();
        Double? yPrice = y.Price.getCommonPrice();

        if (x == null || (xPrice == null) && (y == null || yPrice == null))
            return 0;
        if (x == null || xPrice == null)
            return 1;
        if (y == null || yPrice == null)
            return -1;
        // return 0 if prices are equal
        if (xPrice == yPrice)
            return 0;
        
        // return 1 if x is more than y
        if (xPrice > yPrice)
            return 1;
        
        // return -1 if y is more than x
        return -1;
    }
}