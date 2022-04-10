using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.SiteData;
using WebApp.Services;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    private readonly ISearchItemService SearchItemService;
    private readonly IResutlSorting ResutlSorting;

    public SearchController(ISearchItemService searchItemService, IResutlSorting resutlSorting)
    {
        this.SearchItemService = searchItemService;
        this.ResutlSorting = resutlSorting;
    }

    [HttpPost]
    public IActionResult SearchItem([FromForm] SearchModel searchModel)
    {

        List<AbstractWebItem> scrappedItems = SearchItemService.FindItemByTitle(searchModel.ToSearch);
        List<AbstractWebItem> sortedItems = ResutlSorting.ApplySorting(scrappedItems, searchModel.SortArgs);
        ViewBag.Items = sortedItems;
        return View();
    }
}