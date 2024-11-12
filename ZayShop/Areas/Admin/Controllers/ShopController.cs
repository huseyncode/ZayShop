using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayShop.Areas.Admin.Models.Shop;
using ZayShop.Data;
using ZayShop.Entities;

namespace ZayShop.Areas.Admin.Controllers;

[Area("Admin")]
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
            StyleCategories = _context.StyleCategories.Select(x => new StyleCategory
            {
                Name = x.Name
            }).ToList()
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
    public IActionResult Create(ShopCategoryCreateVM model)
    {
        if (!ModelState.IsValid) return View();

        var styleCategory = _context.StyleCategories.FirstOrDefault(wc => wc.Name.ToLower() == model.Name.ToLower());
        if (styleCategory is not null)
        {
            ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
            return View();
        }

        styleCategory = new StyleCategory
        {
            Name = model.Name
        };

        _context.StyleCategories.Add(styleCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion


    [HttpGet]
    public IActionResult Update(int id)
    {
        int id1 = id;
        if (id1 == 0) return NotFound();

        var styleCategory = _context.StyleCategories.Find(id);
        if (styleCategory is null) return NotFound();

        var model = new StyleCategoryUpdateVM
        {
            Name = styleCategory.Name
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, StyleCategoryUpdateVM model)
    {
        if (id == 0) return NotFound();

        if (!ModelState.IsValid) return View(model);
        var styleCategory = _context.StyleCategories.Find(id);
        if (styleCategory is null) return NotFound();

        var isExist = _context.StyleCategories.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);
        if (isExist)
        {
            ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
            return View(model);
        }

        if (styleCategory.Name != model.Name)
            styleCategory.UpdatedAt = DateTime.Now;

        styleCategory.Name = model.Name;

        _context.StyleCategories.Update(styleCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (id == 0) return NotFound();

        var styleCategory = _context.StyleCategories.Find(id);
        if (styleCategory is null) return NotFound();

        _context.StyleCategories.Remove(styleCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

}
