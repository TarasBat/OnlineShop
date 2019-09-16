using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [Table("PurchaseGoods")]
    public class PurchaseGoods
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Goods")]
        public int GoodsID { get; set; }

        public int Amount { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseID { get; set; }

        public string BuyerID { get; set; }

        public virtual Goods Goods { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
