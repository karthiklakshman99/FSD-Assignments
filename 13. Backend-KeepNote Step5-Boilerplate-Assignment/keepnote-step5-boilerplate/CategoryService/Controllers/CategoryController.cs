using CategoryService.Models;
using CategoryService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CategoryService.API.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("api/category")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category data is invalid.");
            }

            var existingCategory = _categoryService.GetCategoryById(category.Id);
            if (existingCategory != null)
            {
                return Conflict("Category with the same ID already exists.");
            }

            var createdCategory = _categoryService.CreateCategory(category);
            return Created("Data Created successfully",$"{createdCategory}");
        }

        [HttpDelete]
        [Route("api/category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            var result = _categoryService.DeleteCategory(id);
            if (result)
            {
                return Ok("Category deleted successfully.");
            }

            return StatusCode(500, "Failed to delete category.");
        }

        [HttpPut]
        [Route("api/category/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Invalid category data.");
            }

            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            var updated = _categoryService.UpdateCategory(id, category);
            if (updated)
            {
                return Ok("Category updated successfully.");
            }

            return StatusCode(500, "Failed to update category.");
        }

        [HttpGet]
        [Route("api/category/{userId}")]
        public IActionResult GetCategoriesByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var categories = _categoryService.GetAllCategoriesByUserId(userId);
            if (categories == null || !categories.Any())
            {
                return NotFound($"No categories found for user ID {userId}.");
            }

            return Ok(categories);
        }


        [HttpGet]
        [Route("api/category/{categoryId}")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound($"Category with ID {categoryId} not found.");
            }

            return Ok(category);
        }

    }
}
