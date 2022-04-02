using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    [HttpPost]
    public IActionResult SearchItem([FromForm] SearchModel searchModel)
    {
        ViewBag.Countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" }; // Example of ViewBag
        ViewBag.Request = searchModel.ToSearch; // Example of ViewBag
        //TODO logic
        return View();
    }
}