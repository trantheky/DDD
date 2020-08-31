using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Input;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Output;
using OrderManagement.Application.ViewModel;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService) : base()
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<VMOrder>> Get()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpGet]
        [Route("history/{customerId}")]
        public async Task<List<VMOrder>> GetOrderHistory(string customerId)
        {
            var orders = await _orderService.GetOrderHistory(customerId);
            return orders;
        }

        [HttpGet]
        [Route("tracking/{orderId}")]
        public async Task<List<VMTransitLocation>> GetOrderTrackingInfo(int orderId)
        {
            var transitLocations = await _orderService.GetOrderTrackingInfo(orderId);
            return transitLocations;
        }

        [HttpPost]
        public async Task<PlaceOrderResponse> PlaceOrder([FromBody] PlaceOrderRequest placeOrderRequest)
        {
            var placeOrderResponse = await _orderService.PlaceOrder(placeOrderRequest);
            return placeOrderResponse;
        }
    }
}
