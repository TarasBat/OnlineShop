using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Services
{
    public class GoodsService : IGoodsService
    {
        IGoodsRepository _goodsRepository;

        public GoodsService()
        {
        }

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        public void AddGoods(Goods item)
        {
            _goodsRepository.AddGoods(item);
        }

        public void DeleteGoods(int id)
        {
            _goodsRepository.DeleteGoods(id);
        }

        public Goods GetById(int id)
        {
            return _goodsRepository.GetById(id);
        }

        public IQueryable<Goods> GetBySellerID(string id)
        {
            return _goodsRepository.MerchandiseList();//.Where(x=>x.SellerID==id);

        }

        public IQueryable<Goods> MerchandiseList()
        {
            return _goodsRepository.MerchandiseList();
        }

    }
}