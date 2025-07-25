using BusinessObjects;
using DataAccessObjects.Define;

namespace DataAccessObjects.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EStoreContext _context;
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderDetail> OrderDetails { get; }
        public IGenericRepository<Category> Categorys { get; }
        public IMemberRepository Members { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(EStoreContext context, IMemberRepository members, IProductRepository products, IGenericRepository<Category> categories)
        {
            _context = context;
            Members = members;
            Products = products;
            Categorys = categories;
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
