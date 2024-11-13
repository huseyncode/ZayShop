using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Products;

public class ProductCreateVM
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Size options are required.")]
    public string SizeOptions { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Photo path is required.")]
    public string PhotoPath { get; set; }

    [Range(0, 5, ErrorMessage = "Average rating must be between 0 and 5.")]
    public double AverageRating { get; set; }
}
