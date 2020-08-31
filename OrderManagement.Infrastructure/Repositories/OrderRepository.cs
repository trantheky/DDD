using OrderManagement.Domain;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderManagementContext context) : base(context) { }       
    }
}
