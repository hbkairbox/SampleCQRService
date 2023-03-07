namespace SampleCQRService.Infrastructure.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }

    public Category(string categoryName = default, decimal price = default)
    {
        CategoryName = categoryName;
        Price = price;
    }
}