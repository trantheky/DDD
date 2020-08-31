using AutoMapper;
using OrderManagement.Application.Input;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Output;
using OrderManagement.Application.ViewModel;
using OrderManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services
{
    internal class OrderService : IOrderService
    {        
        private ICostCalculatorService _costCalculatorService;        
        private IProductAvailabilityService _productAvailabilityService;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public OrderService(ICostCalculatorService costCalculatorService, 
                            IProductAvailabilityService productAvailabilityService,
                            IUnitOfWork unitOfWork,
                            IMapper mapper)
        {            
            _costCalculatorService = costCalculatorService;
            _unitOfWork = unitOfWork;
            _productAvailabilityService = productAvailabilityService;
            _mapper = mapper;
        }

        public async Task<List<VMOrder>> GetAllOrders()
        {
            var results = await _unitOfWork.OrderRepos.GetAllAsync();
            return _mapper.Map<List<Domain.Order>, List<VMOrder>>(results.ToList());
        }

        public async Task<List<VMOrder>> GetOrderHistory(string customerId)
        {
            // Load orders from the repository
            var orders = await _unitOfWork.OrderRepos.FindAsync(c => c.CustomerId == customerId);

            //Convert to output contracts and return
            return _mapper.Map<List<Domain.Order>, List<VMOrder>>(orders.ToList());            
        }

        public async Task<List<VMTransitLocation>> GetOrderTrackingInfo(int orderId)
        {
            //Load order from the repository
            var domainOrder = await _unitOfWork.OrderRepos.GetAsync(orderId);
            if (domainOrder == null)
                return new List<VMTransitLocation>();

            //Load the transit locations
            var transitionLocations = await _unitOfWork.OrderTrackingRepos.GetTransitLocations(orderId);            
            return _mapper.Map<List<Domain.TransitLocation>, List<VMTransitLocation>>(transitionLocations);            
        }

        public async Task<PlaceOrderResponse> PlaceOrder(PlaceOrderRequest request)
        {            
            //Perform domain validation
            if (CanPlaceOrder(request))
            {
                var domainOrder = new Domain.Order()
                {
                    DatePlaced = DateTime.Now,
                    CustomerId = request.Order.CustomerId,
                    PromotionCode = request.Order.PromotionCode,
                    BillingAddress = request.Order.BillingAddress,
                    OrderLines = request.Order.OrderLines,
                    ShippingAddress = request.Order.ShippingAddress,
                    ShippingCost = request.Order.ShippingCost,
                    TotalCost = request.Order.TotalCost,
                    TransitLocations = request.Order.TransitLocations
                };
                //store the order in the repository
                await _unitOfWork.OrderRepos.AddAsync(domainOrder);
                _unitOfWork.Complete();
                var response = PlaceOrderResponse.Create(true, string.Empty, domainOrder.Id);
                //publish
                //_publisher.Publish(MapToContract(domainOrder, orderId));
                return response;
            }
            else
            {
                var response = PlaceOrderResponse.Create(false, "Order validation failed", null);
                return response;
            }
        }

        private bool CanPlaceOrder(PlaceOrderRequest request)
        {
            //An order must have at least one line
            if (!request.Order.OrderLines.Any())
                return false;

            //All products must be available to order
            foreach (var line in request.Order.OrderLines)
            {
                if (!_productAvailabilityService.CheckProductAvailability(line.Product.Stockcode, line.Quantity))
                    return false;
            }

            //The calculated costs must match the expected ones 
            var shippingCost = _costCalculatorService.CalculateShippingPrice(request.Order.OrderLines.Select(x => x.Product).ToList(),
                                                                             request.Order.ShippingAddress);
            var totalCost = _costCalculatorService.CalculateTotalPrice(request.Order.OrderLines.ToList(), request.Order.PromotionCode);            
            if (totalCost != request.ExpectedTotalCost || shippingCost != request.ExpectedShippingCost)
                return false;

            //if all checks succeeded, return true
            return true;
        }
                
    }
}
