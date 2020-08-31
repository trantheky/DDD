using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.ViewModel
{
    public class VMOrderLine
    {
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }        
        public VMProduct Product { get; set; }        
        public VMOrder Order { get; set; }

        private VMOrderLine(VMProduct product, int quantity, decimal unitPrice, VMOrder order)
        {
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Order = order;
        }            
    }
}
