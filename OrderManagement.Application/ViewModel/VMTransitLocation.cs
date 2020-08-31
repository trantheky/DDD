using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.ViewModel
{
    public class VMTransitLocation
    {
        public int TransitLocationId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public VMAddress Address { get; set; }        
        public VMOrder Order { get; set; }

        [JsonConstructor]
        private VMTransitLocation(string name, DateTime date, VMAddress address, VMOrder order)
        {
            Name = name;
            Date = date;
            Address = address;
            Order = order;
        }

        public static VMTransitLocation Create(string name, DateTime date, VMAddress address, VMOrder order)
        {
            return new VMTransitLocation(name, date, address, order);
        }
    }
}
