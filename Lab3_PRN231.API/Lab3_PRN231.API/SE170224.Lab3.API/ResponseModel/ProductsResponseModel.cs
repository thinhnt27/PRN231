namespace Lab3_PRN231.API.ResponseModel
{
    public class ProductsResponseModel
    {
        public IEnumerable<ProductResponseModel> Products { get; set; } = new List<ProductResponseModel>();
        public int Total { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
