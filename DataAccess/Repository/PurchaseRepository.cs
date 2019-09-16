using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void AddPurchase(Purchase item)
        {
            db.Purchases.Add(item);
            this.SaveChanges();
        }

        public void DeletePurchase(int id)
        {
            var item = this.GetById(id);

            if (item != null)
            {
                db.Purchases.Remove(item);
                this.SaveChanges();
            }
        }

        public Purchase GetById(int id)
        {
            return db.Purchases.Where(x => x.ID == id).FirstOrDefault();
        }

        public IQueryable<Purchase> PurchaseList()
        {
            return db.Purchases;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Purchase GetOrCreate(string buyerId)
        {
            var result = db.Purchases.Where(x => x.PaymentStatus == false && db.PurchaseGoods.Where(y => y.PurchaseID == x.ID).FirstOrDefault().BuyerID == buyerId).FirstOrDefault() ?? new Purchase();
            db.SaveChanges();
            return result;
        }
    }
}
