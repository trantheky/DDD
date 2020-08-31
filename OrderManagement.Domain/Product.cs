using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Stockcode { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal VolumetricWeight { get; set; }        
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
