using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class SearchController : Controller
{
    public IActionResult SearchPage()
    {
        return View();
    }
}
