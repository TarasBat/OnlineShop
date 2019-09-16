using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Services
{
    public class PurchaseService : IPurchaseService
    {
        IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public void AddPurchase(Purchase item)
        {
            _purchaseRepository.AddPurchase(item);
        }

        public void DeletePurchase(int id)
        {
            _purchaseRepository.DeletePurchase(id);
        }

        public Purchase GetById(int id)
        {
            return _purchaseRepository.GetById(id);
        }

        public IQueryable<Purchase> PurchaseList()
        {
            return _purchaseRepository.PurchaseList();
        }

        public void SaveChanges()
        {
            _purchaseRepository.SaveChanges();
        }
        public Purchase GetOrCreate(string buyerId)
        {
            return _purchaseRepository.GetOrCreate(buyerId);
        }
    }
}