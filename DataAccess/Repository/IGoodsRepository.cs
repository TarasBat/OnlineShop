using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGoodsRepository
    {
        IQueryable<Goods> MerchandiseList();

        Goods GetById(int id);

        void AddGoods(Goods item);

        void DeleteGoods(int id);
    }
}
