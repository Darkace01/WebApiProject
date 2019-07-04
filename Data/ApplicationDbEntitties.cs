using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ECommerceStoreWebApi.Models;

namespace ECommerceStoreWebApi.Data
{
    public class ApplicationDbEntitties : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbEntitties>
    {
        protected override void Seed(ApplicationDbEntitties context)
        {
            var product = new Product
            {
                ItemName = "Rice",
                ItemPrice = 34,
                Description = "Bag Of Rice",
                Quantity = 34,

            };
            context.Products.Add(product);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}