using Microsoft.AspNetCore.Mvc;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Areas.Admin.Models.Styles;
using ZayShop.Data;
using ZayShop.Models.Shop;

namespace ZayShop.Areas.Admin.Controllers;
[Area("Admin")]
public class StylesController : Controller
{
    private readonly AppDbContext _context;
    public StylesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var model = new StyleIndexVM
        {
            Styles = _context.StyleCategories.ToList()
        };
        return View(model);

    }
}
