using ECommerceStoreWebApi.Core;
using ECommerceStoreWebApi.Core.Domain;
using ECommerceStoreWebApi.Core.Repositories;
using ECommerceStoreWebApi.Persistence.Repositories;

namespace ECommerceStoreWebApi.Persistence
{   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerce _context;

        public UnitOfWork(ECommerce context)
        {
            _context = context;
            Shops = new ShopRepository(_context);
        }

        public IShopRepository Shops { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private ShopRepository shopRepository;
        public ShopRepository ShopRepository
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(_context);
                return shopRepository;
            }
        }
    }
}