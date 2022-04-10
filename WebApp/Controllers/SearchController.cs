using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.Representation;
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

        List<IRepresentableItem> scrappedItems = SearchItemService.FindItemByTitle(searchModel.ToSearch);
        List<IRepresentableItem> sortedItems = ResutlSorting.ApplySorting(scrappedItems, searchModel.SortArgs);
        ViewBag.Items = sortedItems;
        return View();
    }
}