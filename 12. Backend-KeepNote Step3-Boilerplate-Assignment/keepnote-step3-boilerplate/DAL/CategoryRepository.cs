using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KeepDbContext _dbContext;
        public CategoryRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            category.CategoryCreationDate = DateTime.UtcNow;
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }
        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
                return false;

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }
        //* This method should be used to get all category by userId.
        public List<Category> GetAllCategoriesByUserId(int userId)
        {
            return _dbContext.Categories
                             .Where(c => c.User.UserId == userId)
                             .ToList();
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            existingCategory.CategoryCreatedBy = category.CategoryCreatedBy;
            existingCategory.CategoryCreationDate = DateTime.UtcNow;

            _dbContext.Entry(existingCategory).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
