using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
    * Service classes are used here to implement additional business logic/validation
    * */
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        /*
        Use constructor Injection to inject all required dependencies.
            */
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            if (category == null)
            {
                throw new CategoryNotFoundException(nameof(category));
            }

            return _categoryRepository.CreateCategory(category);
        }

        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            return category == null ? throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist") : _categoryRepository.DeleteCategory(categoryId);
        }

        /*
	     * This method should be used to get all category by userId.
	     */
        public List<Category> GetAllCategoriesByUserId(int userId)
        {
            return _categoryRepository.GetAllCategoriesByUserId(userId);
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            return category ?? throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(int categoryId, Category category)
        {
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }

            _ = _categoryRepository.GetCategoryById(categoryId) ?? throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");

            return _categoryRepository.UpdateCategory(category);
        }
    }
}
