using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Member> Members { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderDetail> OrderDetails { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Category> Categorys { get; }
        void Save();
    }
}
