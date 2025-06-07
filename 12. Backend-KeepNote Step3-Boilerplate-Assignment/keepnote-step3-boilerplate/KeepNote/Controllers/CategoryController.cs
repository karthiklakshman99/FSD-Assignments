using Microsoft.AspNetCore.Mvc;
using Service;
using Entities;
using Exceptions;
using System.Collections.Generic;
using System;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        // Constructor Injection for CategoryService
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /*
         * Create a new category
         * Returns:
         *  - 201 (Created) if successful
         *  - 409 (Conflict) if category already exists
         */
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                var createdCategory = _categoryService.CreateCategory(category);
                return Created("", createdCategory); // 201 Created
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
        }

        /*
         * Delete a category by ID
         * Returns:
         *  - 200 (OK) if deleted successfully
         *  - 404 (Not Found) if category does not exist
         */
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleted = _categoryService.DeleteCategory(id);
            if (deleted)
            {
                return Ok(new { message = "Category deleted successfully" });
            }
            return NotFound(new { message = "Category not found" });
        }

        /*
         * Update a category
         * Returns:
         *  - 200 (OK) if updated successfully
         *  - 404 (Not Found) if category does not exist
         */
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                bool updated = _categoryService.UpdateCategory(id, category);
                if (updated)
                {
                    return Ok(new { message = "Category updated successfully" });
                }
                return NotFound(new { message = "Category not found" });
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /*
         * Get all categories by User ID
         * Returns:
         *  - 200 (OK) with list of categories
         */
        [HttpGet("{userId}")]
        public IActionResult GetAllCategoriesByUserId(int userId)
        {
            List<Category> categories = _categoryService.GetAllCategoriesByUserId(userId);
            return Ok(categories);
        }
    }
}
