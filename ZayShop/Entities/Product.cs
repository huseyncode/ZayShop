namespace ZayShop.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string SizeOptions { get; set; }
    public decimal Price { get; set; }
    public string PhotoPath { get; set; }
    public double AverageRating { get; set; }
}
