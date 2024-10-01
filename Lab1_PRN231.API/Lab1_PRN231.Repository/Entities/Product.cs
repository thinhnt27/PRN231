using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_PRN231.Repository.Entities;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; }

    [Required]
    public int UnitsInStock { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}

