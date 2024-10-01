using Lab1_PRN231.Repository.Entities;
using Lab1_PRN231.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_PRN231.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();

            var isUpdated = await _productService.UpdateProductAsync(id, product);
            if (!isUpdated) return NotFound();

            return NoContent();
        }

        [HttpPost("product")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productService.InsertProductAsync(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }

}
