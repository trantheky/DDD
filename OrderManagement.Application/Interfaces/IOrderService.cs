using OrderManagement.Application.Input;
using OrderManagement.Application.Output;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<VMOrder>> GetAllOrders();
        Task<PlaceOrderResponse> PlaceOrder(PlaceOrderRequest request);
        Task<List<VMOrder>> GetOrderHistory(string customerId);
        Task<List<VMTransitLocation>> GetOrderTrackingInfo(int orderId);
    }
}
