using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Controllers;
using OnlineShop.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace OnlineShop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IGoodsRepository, GoodsRepository>();
            container.RegisterType<IGoodsService, GoodsService>();
            container.RegisterType<IAddGoodsService, AddGoodsService>();
            container.RegisterType<ICategoryServise, CategoryService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IPurchaseGoodsRepository, PurchaseGoodsRepository>();
            container.RegisterType<IPurchaseGoodsService, PurchaseGoodsService>();
            container.RegisterType<IPurchaseRepository, PurchaseRepository>();
            container.RegisterType<IPurchaseService, PurchaseService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<BuyerController>(new InjectionConstructor());
            //container.RegisterType<SellerController>(new InjectionConstructor());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}