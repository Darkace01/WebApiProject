using System.ComponentModel.DataAnnotations;

namespace ECommerceStoreWebApi.Core.Domain
{
    public class Shop
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Item name is required")]
        public string ShopName { get; set; }
        [Required]
        public double Category { get; set; }
        public int TotalProduct { get; set; }
    }
}