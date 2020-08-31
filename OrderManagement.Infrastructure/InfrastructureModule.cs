using Autofac;
using OrderManagement.Infrastructure.Interfaces;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Infrastructure.Services;

namespace OrderManagement.Infrastructure
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderTrackingRepository>().As<IOrderTrackingRepository>();
            builder.RegisterType<ProductAvailabilityService>().As<IProductAvailabilityService>();
        }
    }
}
