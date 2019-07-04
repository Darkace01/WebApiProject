using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceStoreWebApi.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}