using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Slider;

public class SliderCreateVM
{
    [Required(ErrorMessage = "Header1 is required.")]
    [MinLength(3, ErrorMessage = "Header 1 must be at least 3 characters long.")]
    public string Header1 { get; set; }

    [Required(ErrorMessage = "Header 2 is required.")]
    [MinLength(3, ErrorMessage = "Header2 must be at least 3 characters long.")]
    public string Header2 { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
    public string Description { get; set; }

    public string PhotoPath { get; set; }
}
