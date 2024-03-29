using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BusinessModel.Enum;
using WebApp.Services;

namespace WebApp.Controllers;

public class ResultController : Controller
{
    private readonly ISearchItemService SearchItemService;

    public ResultController(ISearchItemService searchItemService)
    {
        this.SearchItemService = searchItemService;
    }

    [HttpPost]
    public IActionResult ResultPage([FromForm] SearchModel searchModel)
    {
        ViewBag.Items = SearchItemService.FindItemByTitle(searchModel.ToSearch, searchModel.UsedSites);
        ViewBag.Sites = searchModel.UsedSites.Where(x => x.Value).Select(x => StoresNames.GetFullName(x.Key)).ToList();
        return View();
    }
}