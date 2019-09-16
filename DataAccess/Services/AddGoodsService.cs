using DataAccess.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAccess.Services
{
    public class AddGoodsService : IAddGoodsService
    {
        public AddGoodsViewModel LoadAddGoodsView()
        {
            CategoryRepository db = new CategoryRepository();
            var categoriesList = db.CategoriesList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString(),
            }).ToList();
            categoriesList.Insert(0, new SelectListItem
            {
                Text = "",
                Value = ""
            });
            var model = new AddGoodsViewModel
            {
                CategoriesList = categoriesList
            };

            return model;
        }
    }
}