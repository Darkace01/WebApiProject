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
    /// <summary>
    /// Product controller
    /// NOTE: This is version One (1
    /// </summary>
    [RoutePrefix("api/v1/Product")]
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Gets The List of product from the database.
        /// </summary>
        [Route("allProduct")]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Products.ToList());
            }
        }

        /// <summary>
        /// Looks up product data by ID.
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        [Route("product/{id}")]
        public Product Get(int id)
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                return entities.Products.FirstOrDefault(e => e.ID == id);
            }
        }

        /// <summary>
        /// Adds product to the database
        /// </summary>
        [Route("save")]
        public HttpResponseMessage Post(Product product)
        {
            try
            {
                using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
                {
                    if (product.ItemName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotModified);
                    }
                    else if (product.ItemPrice < 0)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotModified);
                    }
                    else
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
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Adds product by the given ID
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        /// <param name="product">The product to be added</param>
        [Route("update")]
        public void Put(int id, [FromBody]Product product)
        {
            using (ApplicationDbEntitties entities = new ApplicationDbEntitties())
            {
                if (product.ItemName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else if (product.ItemPrice < 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else
                {

                    var entity = entities.Products.FirstOrDefault(e => e.ID == id);

                    entity.ItemName = product.ItemName;
                    entity.ItemPrice = product.ItemPrice;
                    entity.Quantity = product.Quantity;
                    entity.Description = product.Description;

                    entities.SaveChanges();
                }
            }

        }
      
        /// <summary>
        /// Deleted product by the given ID.
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        [Route("delete")]
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
