using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.ViewModel
{
    public class VMOrder
    {
        public int Id { get; set; }
        public virtual ICollection<VMOrderLine> OrderLines { get; set; }
        public string CustomerId { get; set; }       
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public VMAddress BillingAddress { get; set; }
        public VMAddress ShippingAddress { get; set; }
        public string PromotionCode { get; set; }
        public DateTime DatePlaced { get; set; }
        public ICollection<VMTransitLocation> TransitLocations { get; set; }

        [JsonConstructor]
        private VMOrder(int orderId, List<VMOrderLine> orderLines, string customerId, decimal totalCost, decimal shippingCost, VMAddress billingAddress, VMAddress shippingAddress, string promotionCode, DateTime datePlaced, List<VMTransitLocation> transitLocations)
        {
            Id = orderId;
            OrderLines = orderLines;
            CustomerId = customerId;
            TotalCost = totalCost;
            ShippingCost = shippingCost;
            PromotionCode = promotionCode;
            DatePlaced = datePlaced;
            TransitLocations = transitLocations;
        }

        public static VMOrder Create(int orderId, List<VMOrderLine> orderLines, string customerId, decimal totalCost, 
                                     decimal shippingCost, VMAddress billingAddress, VMAddress shippingAddress, string promotionCode,
                                     DateTime datePlaced)
        {
            return new VMOrder(orderId, orderLines, customerId, totalCost, shippingCost, billingAddress, shippingAddress, promotionCode, datePlaced, null);
        }       

    }
}
