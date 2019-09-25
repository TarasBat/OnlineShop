using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
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
}
