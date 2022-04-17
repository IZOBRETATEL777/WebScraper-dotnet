using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.Representation;
using WebApp.Services;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    private readonly ISearchItemService SearchItemService;

    public SearchController(ISearchItemService searchItemService)
    {
        this.SearchItemService = searchItemService;
    }

    [HttpPost]
    public IActionResult SearchItem([FromForm] SearchModel searchModel)
    {

        ViewBag.Items = SearchItemService.FindItemByTitle(searchModel.ToSearch);;
        return View();
    }
}