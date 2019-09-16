using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAccess.Models
{
    public class GoodsModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string SellerId { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
    }

    public class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ShoppingHistoryModel
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class AddGoodsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; }
    }
}
