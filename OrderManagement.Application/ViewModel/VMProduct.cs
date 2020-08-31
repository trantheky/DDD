using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.ViewModel
{
    public class VMProduct
    {
        public int ProductId { get; set; }
        public int Stockcode { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal VolumetricWeight { get; set; }        

        [JsonConstructor]
        private VMProduct(int stockcode, string productImageUrl, decimal volumetricWeight)
        {
            Stockcode = stockcode;
            ProductImageUrl = productImageUrl;
            VolumetricWeight = volumetricWeight;            
        }

        public static VMProduct Create(int stockcode, string productImageUrl, decimal volumetricWeight)
        {
            return new VMProduct(stockcode, productImageUrl, volumetricWeight);
        }        
    }
}
