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
            StyleCategories = _context.StyleCategories.Select(sc => new StyleCategoryVM
            {
                Name = sc.Name
            }).ToList(),

            Products = _context.Products.Select(p => new ProductVM
            {
                Name = p.Name,
                SizeOptions = p.SizeOptions,
                Price = p.Price,
                PhotoPath = p.PhotoPath,
                AverageRating = p.AverageRating
            }).ToList()
        };
        return View(model);
    }
}
