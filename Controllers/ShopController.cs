using ECommerceStoreWebApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ECommerceStoreWebApi.Core;

namespace ECommerceStoreWebApi.Controllers
{
    [RoutePrefix("api/v1/Shop")]
    public class ShopController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Gets all the shops in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            _unitOfWork.Shops.GetAll();
            _unitOfWork.Complete();
            return Get();
        }
        /// <summary>
        /// Gets the shop by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            _unitOfWork.Shops.Get(Id);
            _unitOfWork.Complete();
            return Get(Id);
        }
        /// <summary>
        /// Adds shop to the database
        /// 
        /// </summary>
        /// <param name="entity"></param>
        [HttpPost]
        [Route("save")]
        public void Add(Shop entity)
        {
            try
            {
                _unitOfWork.Shops.Add(new Shop
                {
                    ShopName = entity.ShopName,
                    Category = entity.Category,
                    TotalProduct = entity.TotalProduct
                });
                _unitOfWork.Complete();
            }
            catch {

            }
        }
        [HttpPut]
        public void Update(int id)
        {
            Shop model = new Shop();
            Shop author = _unitOfWork.Shops.Get(id);
            if (author != null)
            {
                model.ShopName = author.ShopName;
                model.Category = author.Category;
                model.TotalProduct = author.TotalProduct;
            }
            _unitOfWork.Complete();
        }

        public void Remove(int id)
        {
            Shop book = _unitOfWork.Shops.Get(id);
            if (book != null)
            {
                _unitOfWork.Shops.Remove(book);
            }
            _unitOfWork.Complete();
        }
    }
}
