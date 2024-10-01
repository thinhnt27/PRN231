using Lab3_PRN231.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PRN231.Service.BusinessModels
{
    public class ProductsModel
    {
        public IEnumerable<ProductModel> Products { get; set; }

        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public ProductsModel(IEnumerable<ProductModel> products, int total, int page, int pageSize)
        {
            Products = products;
            Total = total;
            Page = page;
            PageSize = pageSize;
        }
    }
}
