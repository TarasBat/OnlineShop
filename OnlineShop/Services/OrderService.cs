using DataAccess;
using DataAccess.Repository;
using OnlineShop.Models;
using OnlineShop.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Services
{
    public class PurchaseGoodsService : IPurchaseGoodsService
    {

        IPurchaseGoodsRepository _orderRepository;

        IGoodsService _IGoodsService;

        ICategoryServise _iCategoryServise;

        public PurchaseGoodsService(IPurchaseGoodsRepository iorderRepository, IGoodsService iGoodsService, ICategoryServise iCategoryServise)
        {
            _orderRepository = iorderRepository;
            _IGoodsService = iGoodsService;
            _iCategoryServise = iCategoryServise;
        }

        public void AddOrder(PurchaseGoods item)
        {
            _orderRepository.AddPurchaseGoods(item);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeletePurchaseGoods(id);
        }

        public PurchaseGoods GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IQueryable<PurchaseGoods> OrderList()
        {
            return _orderRepository.PurchaseGoodsList();
        }

        public IEnumerable<OrderModel> GetSalesHistory(string SellerId)
        {
            var result = _orderRepository.GetSalesHistory(SellerId);
            return result;
        }

        public void SaveChanges()
        {
            _orderRepository.SaveChanges();
        }
    }
} // [Online_shop].[dbo].[Categories].[Name],