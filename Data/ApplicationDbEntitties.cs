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

    
}