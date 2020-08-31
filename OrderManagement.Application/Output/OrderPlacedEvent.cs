using Newtonsoft.Json;
using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.Output
{
    public class OrderPlacedEvent
    {
        Order Order { get; }

        [JsonConstructor]
        private OrderPlacedEvent(Order order)
        {
            Order = order;
        }

        public static OrderPlacedEvent Create(Order order)
        {
            return new OrderPlacedEvent(order);
        }
    }
}
