using Autofac;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;

namespace OrderManagement.Application
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CostCalculatorService>().As<ICostCalculatorService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
