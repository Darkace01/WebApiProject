using ECommerceStoreWebApi.Data;
using ECommerceStoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceStoreWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public HttpResponseMessage Get()
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                    return Request.CreateResponse(HttpStatusCode.OK,
                                entities.Products.ToList());
            }
        }

        // GET api/products/{id}
        public Product Get(int id)
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                return entities.Products.FirstOrDefault(e => e.ID == id);
            }
        }

        // POST api/product
        public HttpResponseMessage Post(Product product)
        {
            try
            {
                using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
                {
                    var newproduct = new Product() { ItemName = product.ItemName, ItemPrice = product.ItemPrice, Description = product.Description, Quantity = product.Quantity };
                    entities.Products.Add(newproduct);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        product.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/products/{id}
        public void Put(int id, [FromBody]Product product)
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                var entity = entities.Products.FirstOrDefault(e => e.ID == id);

                entity.ItemName = product.ItemName;
                entity.ItemPrice = product.ItemPrice;
                entity.Quantity = product.Quantity;
                entity.Description = product.Description;

                entities.SaveChanges();
            }
        }
        //Delete the product by the given Id
        // DELETE api/product/{id}
        public HttpResponseMessage Delete(int id)
        {
            try { 
                    using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
                    {
                        var entity = entities.Products.FirstOrDefault(e => e.ID == id);
                        if (entity == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                    "Employee with Id = " + id.ToString() + " not found to delete");
                        }
                        else
                        {
                            entities.Products.Remove(entity);
                            entities.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
