using Microsoft.AspNetCore.Mvc;
using ZayShop.Data;
using ZayShop.Models.Home;

namespace ZayShop.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        HomeIndexVM model = new HomeIndexVM();

        List<SliderVM> sliders = _context.Sliders.Select(s => new SliderVM
        {
            Header1 = s.Header1,
            Header2 = s.Header2,
            Description = s.Description,
            PhotoPath = s.PhotoPath

        }).ToList();

        model.Sliders = sliders;

        return View(model);
    }
}
