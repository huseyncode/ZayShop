using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Data;

namespace ZayShop.Areas.Admin.Controllers;
    [Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;
    public SliderController(AppDbContext context)
    {
        _context = context;
    }

    //Genereate Slider Index View
    [HttpGet]
    public IActionResult Index()
    {
        var model= new SliderIndexVM
        {
            Sliders = _context.Sliders.ToList()
        };
        return View(model);
    }
}
