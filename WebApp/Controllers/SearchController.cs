using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.Scrapers;
using BusinessModel.Users;
using BusinessModel.SiteData;
using BusinessModel.Comparers;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    [HttpPost]
    public IActionResult SearchItem([FromForm] SearchModel searchModel)
    {
        string searchItem = searchModel.ToSearch;
        Console.WriteLine("Searched: " + searchItem);

        ViewBag.Countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" }; // Example of ViewBag
        ViewBag.Request = searchItem; // Example of ViewBag
       
        //TODO logic 
        Buyer[] buyers = {
            new Buyer("Donald", "Trump", "donald_j_trump@yande.ru", new TapAzScraper()),
            new Buyer("Jhon", "Doe", "jhon_doe@mail.az", new AmazonScraper()),
            new Buyer("Jack", "Ripper", "bestSeller@gmail.com", new TrendyolScraper()),
        };

        // Scrapping items from sites
        List<AbstractWebItem> scrappedItems = new List<AbstractWebItem> ();
        for (int index = 0 ; index < buyers.Length; index++) {
            Console.WriteLine(index);
            scrappedItems.AddRange(buyers[index].Search(searchItem));
        }

        // Sorting using custom comparator
        PriceComparer pc = new PriceComparer();
        scrappedItems.Sort(pc);

        ViewBag.Items = scrappedItems;
        return View();
    }
}