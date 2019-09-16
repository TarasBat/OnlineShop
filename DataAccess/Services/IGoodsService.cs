using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IGoodsService
    {
        void AddGoods(Goods item);

        void DeleteGoods(int id);

        Goods GetById(int id);

        IQueryable<Goods> GetBySellerID(string id);

        IQueryable<Goods> MerchandiseList();

    }
}
