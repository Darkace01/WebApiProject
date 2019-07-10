using ECommerceStoreWebApi.Core.Domain;
using ECommerceStoreWebApi.Core.Repositories;

namespace ECommerceStoreWebApi.Persistence.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ECommerce context)
            : base(context)
        {
        }

        public ECommerce ECommerce
        {
            get { return Context as ECommerce; }
        }
    }
}