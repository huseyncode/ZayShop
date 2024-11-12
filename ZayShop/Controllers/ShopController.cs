using Microsoft.AspNetCore.Mvc;
using ZayShop.Data;
using ZayShop.Models.Shop;

namespace ZayShop.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var model = new ShopIndexVM
        {
            StyleCategories = _context.StyleCategories.Select(x => new StyleCategoryVM
            {
                Name = x.Name
            }).ToList()
        };
        return View(model);
    }
}
