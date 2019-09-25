using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using DataAccess.Models;
using DataAccess.Repository;
using OnlineShop.Models;
using OnlineShop.Services;
using System.Threading.Tasks;
using DataAccess;

namespace OnlineShop.Controllers
{
    public class SellerController : Controller
    {
        public SellerController(IGoodsService iGoodsService, IAddGoodsService iAddGoodsService, ICategoryServise iCategoryServise, IPurchaseGoodsService iPurchaseGoodsService)
        {
            _iGoodsService = iGoodsService;
            _iAddGoodsService = iAddGoodsService;
            _iCategoryServise = iCategoryServise;
            _IPurchaseGoodsService = iPurchaseGoodsService;
        }
        private IPurchaseGoodsService _IPurchaseGoodsService { get; set; }
        private IGoodsService _iGoodsService { get; set; }
        private IAddGoodsService _iAddGoodsService { get; set; }
        private ICategoryServise _iCategoryServise { get; set; }




        [Authorize(Roles = "Seller")]
        public ActionResult About()
        {
            ViewBag.Message = "Hello seller.";

            return View();
        }

        public ActionResult MyGoods()
        {
            return View();
        }

        public ActionResult SalesHistory()
        {
            return View();
        }


        public ActionResult GetGoodsList()
        {
            var items = _iGoodsService.GetBySellerID(User.Identity.GetUserId());

            List<GoodsModel> result = new List<GoodsModel>();
            foreach(var goods in items)
            {
                result.Add(new GoodsModel { Name = goods.Name, Category = _iCategoryServise.GetNameById(goods.CategoryID), Price = goods.Price });
            }           

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        // POST: /Seller/AddGoods
        [HttpPost]
        public async Task<ActionResult> AddGoods(AddGoodsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var goods = new Goods { Name=model.Name, Price = model.Price, CategoryID = model.CategoryID, SellerID= User.Identity.GetUserId() };
                _iGoodsService.AddGoods(goods);           

                return RedirectToAction("MyGoods", "Seller");
             }
            
            return View(model);
        }

        public ActionResult AddGoods()
        {
            var model = _iAddGoodsService.LoadAddGoodsView();

            return View(model);
        }

        public JsonResult GetCategoriesList(string searchTerm)
        {
            var CategoriesList = _iCategoryServise.CategoriesList();
            var modifiedData = CategoriesList.Select(x => new
            {
                id = x.ID,
                text = x.Name
            });

            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSalesHistory()
        {
            var UserId = User.Identity.GetUserId();

            var result = _IPurchaseGoodsService.GetSalesHistory(UserId);          

            return Json(new {  data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
