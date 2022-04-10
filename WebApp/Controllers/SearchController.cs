using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.SiteData;
using WebApp.Services;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    private readonly ISearchItemService searchItemService;

    public SearchController(ISearchItemService searchItemService)
    {
        this.searchItemService = searchItemService;
    }

    [HttpPost]
    public IActionResult SearchItem([FromForm] SearchModel searchModel)
    {

        List<AbstractWebItem> scrappedItems = searchItemService.FindItemByTitle(searchModel.ToSearch);
        System.Console.WriteLine(searchModel.SortArgs.Count());
        ViewBag.Items = scrappedItems;
        return View();
    }
}