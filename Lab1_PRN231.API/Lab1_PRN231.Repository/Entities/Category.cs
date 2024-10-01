using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_PRN231.Repository.Entities;

public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(40)]
    public string CategoryName { get; set; }

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}

