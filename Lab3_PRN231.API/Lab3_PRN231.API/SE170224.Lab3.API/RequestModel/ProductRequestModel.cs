using Lab3_PRN231.Service.BusinessModel;
using System.ComponentModel.DataAnnotations;

namespace Lab3_PRN231.API.RequestModel
{
    public class ProductRequestModel
    {
        [Required]
        public string? ProductName { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ProductModel ToProductModel()
        {
            return new ProductModel
            {
                ProductName = ProductName,
                UnitsInStock = UnitsInStock,
                UnitPrice = UnitPrice,
                CategoryId = CategoryId
            };
        }
    }
}
