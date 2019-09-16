using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        IQueryable<Category> CategoriesList();

        Category GetById(int id);

        string GetNameById(int id);

        void AddCategory(Category item);

        void DeleteCategory(int id);
    }
}
