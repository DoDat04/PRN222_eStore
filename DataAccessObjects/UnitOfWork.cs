using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EStoreContext _context;
        public IGenericRepository<Member> Members { get; }
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderDetail> OrderDetails { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categorys { get; }

        public UnitOfWork(EStoreContext context)
        {
            _context = context;
            Members = new GenericRepository<Member>(_context);
            Orders = new GenericRepository<Order>(_context);
            OrderDetails = new GenericRepository<OrderDetail>(_context);
            Products = new GenericRepository<Product>(_context);
            Categorys = new GenericRepository<Category>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
