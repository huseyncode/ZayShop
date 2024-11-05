using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
