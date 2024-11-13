using Microsoft.AspNetCore.Mvc;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Areas.Admin.Models.Styles;
using ZayShop.Data;
using ZayShop.Entities;
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

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(StyleCreateVM model)
    {
        if (!ModelState.IsValid) return View(model);
        var style = new StyleCategory
        {
            Name = model.Name
        };
        _context.StyleCategories.Add(style);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        var style = _context.StyleCategories.Find(id);
        if (style is null) return NotFound();
        var model = new StyleUpdateVM
        {
            Name = style.Name
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Update(int id, StyleUpdateVM model)
    {
        if (!ModelState.IsValid) return View(model);
        var style = _context.StyleCategories.Find(id);
        if (style is null) return NotFound();
        style.Name = model.Name;
        style.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var style = _context.StyleCategories.Find(id);
        if (style is null) return NotFound();
        _context.StyleCategories.Remove(style);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    #endregion

}
