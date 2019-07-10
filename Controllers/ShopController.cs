using ECommerceStoreWebApi.Core.Domain;
using ECommerceStoreWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECommerceStoreWebApi.Persistence;
using System.Data.Entity;

namespace ECommerceStoreWebApi.Controllers
{
    public class ShopController : ApiController
    {
        private static ECommerce _Context;
        readonly UnitOfWork uow = new UnitOfWork(_Context);

        private readonly IRepository<Shop> repoShop;
        

        public ShopController(IRepository<Shop> repoShop)
        {
            this.repoShop = repoShop;
        }
        /// <summary>
        /// Gets all the shops in the database
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            repoShop.GetAll().ToList();
            uow.Complete();
            return Get();
        }
        /// <summary>
        /// Gets the shop by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int Id)
        {
            repoShop.Get(Id);
            uow.Complete();
            return Get(Id);
        }
        /// <summary>
        /// Adds shop to the database
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Shop entity)
        {
            try
            {
                Shop shop = new Shop
                {
                    ShopName = entity.ShopName,
                    Category = entity.Category,
                    TotalProduct = entity.TotalProduct

                };
                uow.Complete();
            }
            catch {

            }
        }

        public void Update(int id)
        {
            Shop model = new Shop();
            Shop author = repoShop.Get(id);
            if (author != null)
            {
                model.ShopName = author.ShopName;
                model.Category = author.Category;
                model.TotalProduct = author.TotalProduct;
            }
            uow.Complete();
        }

        public void Remove(int id)
        {
            Shop book = repoShop.Get(id);
            if (book != null)
            {
                repoShop.Remove(book);
            }
            uow.Complete();
        }
    }
}
