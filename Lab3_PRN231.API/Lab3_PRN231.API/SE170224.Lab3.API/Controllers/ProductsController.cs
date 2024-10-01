using Lab3_PRN231.API.RequestModel;
using Lab3_PRN231.API.ResponseModel;
using Lab3_PRN231.Service.BusinessModel;
using Lab3_PRN231.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Lab3_PRN231.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestModel request)
        {
            var result = await _service.CreateProductAsync(request.ToProductModel());
            return Created($"{result.ProductId}", new ProductResponseModel { Product = result});
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { Message = $"Product {id} not found" });
            }

            return Ok(new ProductResponseModel { Product = product});
        }
        [HttpGet("ids")]
        public async Task<IActionResult> GetProductsByIds([FromQuery] List<int> ids)
        {
            var products = await _service.GetProductsByIdsAsync(ids);
            return Ok(products);
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationRequest request)
        {
            var result = await _service.GetProductsAsync(request.PageIndex ?? 0, request.PageSize ?? 10, request.Search ?? "", request.OrderBy ?? "", request.OrderDesc ?? false);
            return Ok(new ProductsResponseModel
            {
                Total = result.Total,
                PageIndex = result.Page,
                PageSize = result.PageSize,
                Products = result.Products.Select(p => new ProductResponseModel { Product = p })
            });
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestModel request)
        {
            var product = await _service.UpdateProductAsync(id, request.ToProductModel());
            if (product == null)
            {
                return NotFound(new { Message = $"Product {id} not found" });
            }
            return Ok(new ProductResponseModel { Product = product });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _service.DeleteProductAsync(id);
            if (!success)
            {
                return NotFound(new { Message = $"Product {id} not found" });
            }
            return Ok(new { Success = true });
        }
    }
}
