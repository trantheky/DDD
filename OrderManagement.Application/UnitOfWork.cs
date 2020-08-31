using OrderManagement.Application.Interfaces;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Interfaces;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementContext _context;

        public UnitOfWork(OrderManagementContext context)
        {
            _context = context;
            OrderRepos = new OrderRepository(_context);
            OrderTrackingRepos = new OrderTrackingRepository(_context);
        }

        public IOrderRepository OrderRepos { get; set; }

        public IOrderTrackingRepository OrderTrackingRepos { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
