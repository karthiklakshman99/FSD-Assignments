using System;
using System.Collections.Generic;
using CategoryService.Models;
using CategoryService.Repository;
using CategoryService.Exceptions;

namespace CategoryService.Service
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentException("Category cannot be null");

            return _repository.CreateCategory(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            var category = _repository.GetCategoryById(categoryId);
            if (category == null)
                throw new CategoryNotFoundException($"Category with ID {categoryId} not found");

            return _repository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty");

            return _repository.GetAllCategoriesByUserId(userId);
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _repository.GetCategoryById(categoryId);
            if (category == null)
                throw new CategoryNotCreatedException($"Category with ID {categoryId} not found");

            return category;
        }

        public bool UpdateCategory(int categoryId, Category category)
        {
            if (category == null)
                throw new ArgumentException("Category cannot be null");

            var existingCategory = _repository.GetCategoryById(categoryId);
            if (existingCategory == null)
                throw new CategoryNotFoundException($"Category with ID {categoryId} not found");

            return _repository.UpdateCategory(categoryId, category);
        }
    }
}
