using DataAccess;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public interface IPurchaseGoodsService
    {
        void AddOrder(PurchaseGoods item);

        void DeleteOrder(int id);
        
        PurchaseGoods GetById(int id);

        void SaveChanges();

        IQueryable<PurchaseGoods> OrderList();
        IEnumerable<OrderModel> GetSalesHistory(string SellerId);
    }
}
