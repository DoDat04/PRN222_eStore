using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Define
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository Members { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderDetail> OrderDetails { get; }
        IProductRepository Products { get; }
        IGenericRepository<Category> Categorys { get; }
        void Save();
    }
}
