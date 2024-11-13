using Microsoft.AspNetCore.Mvc;
using ZayShop.Areas.Admin.Models.Products;
using ZayShop.Data;
using ZayShop.Entities;

namespace ZayShop.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;
    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var model = new ProductIndexVM
        {
            Products = _context.Products.ToList()
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
    public IActionResult Create(ProductCreateVM model)
    {
        if (!ModelState.IsValid) return View(model);
        var product = new Product
        {
            Name = model.Name,
            SizeOptions = model.SizeOptions,
            Price = model.Price,
            AverageRating = model.AverageRating,
            PhotoPath = model.PhotoPath
        };
        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        var model = new ProductUpdateVM
        {
            Name = product.Name,
            SizeOptions = product.SizeOptions,
            Price = product.Price,
            AverageRating = product.AverageRating,
            PhotoPath = product.PhotoPath
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, ProductUpdateVM model)
    {
        if (!ModelState.IsValid) return View();
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        product.Name = model.Name;
        product.SizeOptions = model.SizeOptions;
        product.Price = model.Price;
        product.AverageRating = model.AverageRating;
        product.PhotoPath = model.PhotoPath;
        product.UpdatedAt = DateTime.Now;

        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
