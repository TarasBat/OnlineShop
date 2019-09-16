using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> PurchaseList();

        Purchase GetById(int id);

        void AddPurchase(Purchase item);

        void DeletePurchase(int id);

        void SaveChanges();

        Purchase GetOrCreate(string buyerId);
    }
}
