using ECommerceStoreWebApi.Core.Domain;
using System.Data.Entity;

namespace ECommerceStoreWebApi.Persistence
{
    public class ECommerce : DbContext
    {
        public ECommerce()
            : base("name=PlutoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Shop> Shops { get; set; }
    }
}