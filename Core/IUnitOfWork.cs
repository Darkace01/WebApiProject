using ECommerceStoreWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceStoreWebApi.Core
{
    interface IUnitOfWork : IDisposable
    {
        IProductRepository Authors { get; }
        int Complete();
    }
}
