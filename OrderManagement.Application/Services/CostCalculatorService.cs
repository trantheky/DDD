using OrderManagement.Application.Interfaces;
using OrderManagement.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Application.Services
{
    internal class CostCalculatorService : ICostCalculatorService
    {
        public decimal CalculateShippingPrice(List<Product> products, Address shippingAddress)
        {
            return 50;
        }
        
        public decimal CalculateTotalPrice(List<OrderLine> orderLines, string promotionCode)
        {
            return orderLines.Sum(x => x.UnitPrice * x.Quantity);
        }
    }
}
