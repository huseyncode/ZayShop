using Microsoft.AspNetCore.Mvc;
using ZayShop.Areas.Admin.Models.Products;
using ZayShop.Data;

namespace ZayShop.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;
    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var model = new ProductIndexVM
        {
            Products = _context.Products.ToList()
        };
        return View(model);
    }
}
