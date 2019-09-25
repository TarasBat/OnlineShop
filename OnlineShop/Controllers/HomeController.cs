using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using DataAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            ViewBag.Name = currentUser.Name;
            ViewBag.Surname = currentUser.Surname;
            ViewBag.Email = currentUser.Email;

            return View();
        }

        [Authorize(Roles = "Buyer")]
        public ActionResult About()
        {
            ViewBag.Message = "Hello buyer.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Online shop contact page.";

            return View();
        }
    }

}
