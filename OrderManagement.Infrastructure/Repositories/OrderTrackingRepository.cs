using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain;
using OrderManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderTrackingRepository : Repository<TransitLocation>, IOrderTrackingRepository
    {
        public OrderTrackingRepository(OrderManagementContext context) : base(context) {}

        public async Task<List<TransitLocation>> GetTransitLocations(int orderId)
        {
            return await Context.Set<TransitLocation>().Where(c => c.OrderId == orderId).ToListAsync();
        }
    }
}
