using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GoodsRepository : IGoodsRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void AddGoods(Goods item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                // db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_shop].[dbo].[Goods] ON");
                db.Merchandise.Add(item);
                db.SaveChanges();
                //  db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_shop].[dbo].[Goods] OFF");
                transaction.Commit();
            }
        }

        public void DeleteGoods(int id)
        {
            var item = this.GetById(id);

            if (item != null)
            {
                db.Merchandise.Remove(item);
                this.SaveChanges();
            }
        }

        public Goods GetById(int id)
        {
            return db.Merchandise.Where(x => x.ID == id).FirstOrDefault();
        }

        public IQueryable<Goods> MerchandiseList()
        {
            return db.Merchandise;
        }

        void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}