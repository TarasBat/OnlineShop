using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public interface IPurchaseService
    {
        void AddPurchase(Purchase item);

        void DeletePurchase(int id);
        
        Purchase GetById(int id);

        void SaveChanges();
        IQueryable<Purchase> PurchaseList();
        Purchase GetOrCreate(string buyerId);
    }
}
