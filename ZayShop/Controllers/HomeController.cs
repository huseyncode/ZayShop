using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
