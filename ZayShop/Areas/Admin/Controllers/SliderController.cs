using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Data;
using ZayShop.Entities;

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
        var model = new SliderIndexVM
        {
            Sliders = _context.Sliders.ToList()
        };
        return View(model);
    }
    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(SliderCreateVM model)
    {
        if (!ModelState.IsValid) return View(model);
        var slider = new Slider
        {
            Header1 = model.Header1,
            Header2 = model.Header2,
            Description = model.Description,
            PhotoPath = model.PhotoPath

        };
        _context.Sliders.Add(slider);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion


    #region Update
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var slider = _context.Sliders.Find(id);
        if(slider is null) return NotFound();

        var model = new SliderUpdateVM
        {
            Header1 = slider.Header1,
            Header2 = slider.Header2,
            Description = slider.Description,
            PhotoPath = slider.PhotoPath
        };
        return View(model);
    }


    [HttpPost]
    public IActionResult Update(int id, SliderUpdateVM model)
    {
        if (!ModelState.IsValid) return View();
        var slide = _context.Sliders.Find(id);
        if(slide is null) return NotFound();

        slide.Header1 = model.Header1;
        slide.Header2 = model.Header2;
        slide.Description = model.Description;
        slide.PhotoPath = model.PhotoPath;
        slide.UpdatedAt= DateTime.Now;

        _context.Sliders.Update(slide);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var slide = _context.Sliders.Find(id);
        if (slide is null) return NotFound();

        _context.Sliders.Remove(slide);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
