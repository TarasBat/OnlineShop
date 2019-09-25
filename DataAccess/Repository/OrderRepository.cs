using DataAccess.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models;

namespace DataAccess.Repository
{
    public class PurchaseGoodsRepository : IPurchaseGoodsRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public PurchaseGoodsRepository(IPurchaseRepository iPurchaseService)
        {
            _IPurchaseRepository = iPurchaseService;
        }
        protected IPurchaseRepository _IPurchaseRepository;

        public void AddPurchaseGoods(PurchaseGoods item)
        {       

            var purchase = db.Purchases.Where(x => x.PaymentStatus == false && db.PurchaseGoods.Where(y => y.PurchaseID == x.ID).FirstOrDefault().BuyerID == item.BuyerID).FirstOrDefault();
            

            if (purchase == null)
            {
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_shop].[dbo].[Purchases] ON");
                var newPurchase = new Purchase() { Data = DateTime.Now, PaymentStatus = false, TotalPrice = 0 };
                db.Purchases.Add(newPurchase);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_shop].[dbo].[Purchases] OFF");
                item.PurchaseID = newPurchase.ID;
            }
            else
            {
                item.PurchaseID = purchase.ID;
            }

           
            db.PurchaseGoods.Add(item);
            db.SaveChanges();
        }

        public void DeletePurchaseGoods(int id)
        {
            var item = this.GetById(id);

            if (item != null)
            {
                db.PurchaseGoods.Remove(item);
                this.SaveChanges();
            }
        }

        public PurchaseGoods GetById(int id)
        {
            return db.PurchaseGoods.Where(x => x.ID == id).FirstOrDefault();
        }

        public IQueryable<PurchaseGoods> PurchaseGoodsList()
        {
            return db.PurchaseGoods;
        }

        public IEnumerable<OrderModel> GetSalesHistory(string SellerId)
        {
            var result = from purchaseGoods in db.PurchaseGoods
                         group purchaseGoods by purchaseGoods.GoodsID into groupPurchaseGoods

                         join goods in db.Merchandise on groupPurchaseGoods.Key equals goods.ID  where goods.SellerID == SellerId
                         join categories in db.Categories on goods.CategoryID equals categories.ID

                         select new OrderModel
                         {
                             Name = goods.Name,
                             Category = categories.Name,
                             Price = goods.Price,
                             Amount = groupPurchaseGoods.Count(),
                             TotalPrice = goods.Price * groupPurchaseGoods.Count()
                         };

            return result;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
