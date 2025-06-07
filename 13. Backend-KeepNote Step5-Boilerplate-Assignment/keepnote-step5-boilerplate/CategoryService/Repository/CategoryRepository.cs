using System;
using System.Collections.Generic;
using CategoryService.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CategoryService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.InsertOne(category);
            return category;
        }

        public bool DeleteCategory(int categoryId)
        {
            var result = _context.Categories.DeleteOne(c => c.Id == categoryId);
            return result.DeletedCount > 0;
        }

        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return _context.Categories.Find(c => c.CreatedBy == userId).ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(c => c.Id == categoryId).FirstOrDefault();
        }

        public bool UpdateCategory(int categoryId, Category category)
        {
            var result = _context.Categories.ReplaceOne(
                c => c.Id == categoryId,
                category
            );
            return result.ModifiedCount > 0;
        }
    }
}
