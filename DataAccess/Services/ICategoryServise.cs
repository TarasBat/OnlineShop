using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface ICategoryServise
    {
        void AddCategory(Category item);

        void DeleteCategory(int id);

        Category GetById(int id);

        string GetNameById(int id);

        IQueryable<Category> CategoriesList();
    }
}
