using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Repository;

namespace DataAccess.Services
{
    public class CategoryService : ICategoryServise
    {
        ICategoryRepository _categoryRepository;

        public CategoryService()
        {
        }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category item)
        {
            _categoryRepository.AddCategory(item);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public string GetNameById(int id)
        {
            return _categoryRepository.GetNameById(id);
        }

        public IQueryable<Category> CategoriesList()
        {
            return _categoryRepository.CategoriesList();
        }
    }
}