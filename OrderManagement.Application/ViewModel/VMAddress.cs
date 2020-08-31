using Newtonsoft.Json;
using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.ViewModel
{
    public class VMAddress
    {
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string Country { get; }

        [JsonConstructor]
        private VMAddress(string addressLine1, string addressLine2, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Country = country;
        }
        public static VMAddress Create(string addressLine1, string addressLine2, string country)
        {
            return new VMAddress(addressLine1, addressLine2, country);
        }        
    }
}
