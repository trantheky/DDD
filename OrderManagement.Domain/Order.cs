using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain
{
    public class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }
        public int Id { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public string CustomerId { get; set; }
        public AppUser Customer { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public string PromotionCode { get; set; }
        public DateTime DatePlaced { get; set; }
        public ICollection<TransitLocation> TransitLocations { get; set; }
    }
}
