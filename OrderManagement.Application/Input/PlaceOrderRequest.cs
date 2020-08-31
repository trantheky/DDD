using Newtonsoft.Json;
using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.Input
{
    public class PlaceOrderRequest
    {
        public Order Order { get; }
        public decimal ExpectedTotalCost { get; }
        public decimal ExpectedShippingCost { get; }

        [JsonConstructor]
        private PlaceOrderRequest(Order order, decimal expectedTotalCost, decimal expectedShippingCost)
        {
            Order = order;
            ExpectedTotalCost = expectedTotalCost;
            ExpectedShippingCost = expectedShippingCost;
        }

        public static PlaceOrderRequest Create(Order order, decimal expectedTotalCost, decimal expectedShippingCost)
        {
            return new PlaceOrderRequest(order, expectedTotalCost, expectedShippingCost);
        }
    }
}
