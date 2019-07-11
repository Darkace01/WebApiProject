using ECommerceStoreWebApi.Core.Repositories;
using System;

namespace ECommerceStoreWebApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        int Complete();
    }
}
