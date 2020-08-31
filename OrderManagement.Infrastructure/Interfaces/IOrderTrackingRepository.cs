using OrderManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Interfaces
{
    public interface IOrderTrackingRepository : IRepository<TransitLocation>
    {
        Task<List<TransitLocation>> GetTransitLocations(int orderId);
    }
}
