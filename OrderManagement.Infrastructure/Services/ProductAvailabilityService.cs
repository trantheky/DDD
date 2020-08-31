using OrderManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infrastructure.Services
{
    internal class ProductAvailabilityService : IProductAvailabilityService
    {
        public bool CheckProductAvailability(int stockCode, int quantity)
        {
            return true;
        }
    }
}
