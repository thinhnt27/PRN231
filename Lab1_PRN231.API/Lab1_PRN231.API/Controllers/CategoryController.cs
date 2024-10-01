using Lab1_PRN231.Repository.Entities;
using Lab1_PRN231.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_PRN231.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPut("category/{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId) return BadRequest();

            var isUpdated = await _categoryService.UpdateCategoryAsync(id, category);
            if (!isUpdated) return NotFound();

            return NoContent();
        }

        [HttpPost("category")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _categoryService.InsertCategoryAsync(category);
            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }

        [HttpGet("category/{id}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int id)
        {
            var products = await _categoryService.GetProductsByCategoryIdAsync(id);
            return Ok(products);
        }
    }

}
