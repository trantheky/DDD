using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infrastructure.Interfaces
{
    public interface IProductAvailabilityService
    {
        bool CheckProductAvailability(int stockCode, int quantity);
    }
}
