using ECommerceStoreWebApi.Core.Repositories;
using System;

namespace ECommerceStoreWebApi.Core
{
    interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        int Complete();
    }
}
