using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using OnlineShop.Services;
using OnlineShop.Models;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Models;

namespace OnlineShop.Controllers
{

    public class BuyerController : Controller
    {
        public BuyerController(IGoodsService iGoodsService, IAddGoodsService iAddGoodsService, ICategoryServise iCategoryServise, IPurchaseGoodsService iOrderService, IPurchaseService iPurchaseService)
        {
            _iGoodsService = iGoodsService;
            _iAddGoodsService = iAddGoodsService;
            _iCategoryServise = iCategoryServise;
            _IPurchaseGoodsService = iOrderService;
            _IPurchaseService = iPurchaseService;
        }
        private IPurchaseService _IPurchaseService;
        private IPurchaseGoodsService _IPurchaseGoodsService { get; set; }
        private IGoodsService _iGoodsService { get; set; }
        private IAddGoodsService _iAddGoodsService { get; set; }
        private ICategoryServise _iCategoryServise { get; set; }

        [Authorize(Roles = "Buyer")]
        public ActionResult About()
        {
            ViewBag.Message = "Hello buyer.";

            return View();
        }

        public ActionResult Carts()
        {
            return View();
        }
                
        public ActionResult Goods()
        {
            return View();
        }

        public ActionResult ShoppingHistory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddToCarts(int Id, int Amount)
        {
            //var purchase = _IPurchaseService.GetOrCreate(User.Identity.GetUserId());
            //_IPurchaseService.SaveChanges();
            _IPurchaseGoodsService.AddOrder(new PurchaseGoods { GoodsID = Id, Amount=Amount, BuyerID = User.Identity.GetUserId() } );

            return View();
        }

        public ActionResult GetGoodsList()
        {
            var items = _iGoodsService.MerchandiseList();

            List<GoodsModel> result = new List<GoodsModel>();
            foreach (var goods in items)
            {
                result.Add(new GoodsModel {Id = goods.ID, SellerId = goods.SellerID, Name = goods.Name, Category = _iCategoryServise.GetNameById(goods.CategoryID), Price = goods.Price });
            }

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        //Buyer/GetShoppingHistory
        public ActionResult GetShoppingHistory()
        {
            var UserID = User.Identity.GetUserId();

            var items = _IPurchaseService.PurchaseList().Where(x=> x.PaymentStatus == true);

            List<ShoppingHistoryModel> result = new List<ShoppingHistoryModel>();
            foreach(var purchase in items)
            {
                result.Add(new ShoppingHistoryModel { ID = purchase.ID, Date = purchase.Data.ToString(), TotalPrice = purchase.TotalPrice });
            }


             return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }


        //Buyer/GetOrdersList
        public ActionResult GetOrdersList()
        {
            var UserID = User.Identity.GetUserId();
            var purchase = _IPurchaseService.GetOrCreate(UserID);
            var items = _IPurchaseGoodsService.OrderList().Where(x=>x.BuyerID == UserID && x.PurchaseID == purchase.ID && purchase.PaymentStatus == false);
            //items = items.Where(x => x.BuyerID == UserID);
            List<OrderModel> result = new List<OrderModel>();
            foreach (var order in items)
            {
               result.Add(new OrderModel { Id = order.ID, Name= _iGoodsService.GetById(order.GoodsID).Name, Category = _iCategoryServise.GetNameById(_iGoodsService.GetById(order.GoodsID).CategoryID), Price = _iGoodsService.GetById(order.GoodsID).Price, Amount = order.Amount, TotalPrice = _iGoodsService.GetById(order.GoodsID).Price * order.Amount });
            }

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public void Buy()
        {
            var UserID = User.Identity.GetUserId();
            var purchase = _IPurchaseService.GetOrCreate(UserID);
            var orders = _IPurchaseGoodsService.OrderList().Where(x => x.BuyerID == UserID && x.PurchaseID == purchase.ID && purchase.PaymentStatus == false).ToList();
            if (orders.Capacity > 0)
            {
                decimal totalPrice = 0;
                foreach (var order in orders)
                {
                    totalPrice += _iGoodsService.GetById(_IPurchaseGoodsService.GetById(order.ID).GoodsID).Price*order.Amount;
                }

                purchase.Data = DateTime.Now;
                purchase.TotalPrice = totalPrice;
                purchase.PaymentStatus = true;

                _IPurchaseService.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult GetPurchaseOrders(int PurchaseId)
        {
            List<OrderModel> result = new List<OrderModel>();

            var items = _IPurchaseGoodsService.OrderList().ToList();

            var orders = items.Where(x => x.PurchaseID == PurchaseId);

            foreach(var order in orders)
            {
                result.Add(new OrderModel { Id = order.ID, Name = _iGoodsService.GetById(order.GoodsID).Name, Category = _iCategoryServise.GetNameById(_iGoodsService.GetById(order.GoodsID).CategoryID), Price = _iGoodsService.GetById(order.GoodsID).Price, Amount = order.Amount, TotalPrice = _iGoodsService.GetById(order.GoodsID).Price * order.Amount });
            }

            return this.PartialView("~/Views/Buyer/_PurchaseOrders.cshtml", result);
        }

    }

}

