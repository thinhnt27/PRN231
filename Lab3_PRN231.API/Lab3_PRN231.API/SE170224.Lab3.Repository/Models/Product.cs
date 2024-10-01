namespace Lab3_PRN231.Repository.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UnitsInStock { get; set; }

    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
