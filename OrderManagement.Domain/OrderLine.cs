using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }               
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
