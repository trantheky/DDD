using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain
{
    public class TransitLocation
    {        
        public int TransitLocationId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Address Address { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
