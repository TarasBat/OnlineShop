using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void AddCategory(Category item)
        {
            db.Categories.Add(item);
            this.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var item = this.GetById(id);

            if (item != null)
            {
                db.Categories.Remove(item);
                this.SaveChanges();
            }
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(x => x.ID == id).FirstOrDefault();
        }

        public string GetNameById(int id)
        {
            return db.Categories.Where(x => x.ID == id).FirstOrDefault().Name;
        }

        public IQueryable<Category> CategoriesList()
        {
            return db.Categories;
        }

        void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
