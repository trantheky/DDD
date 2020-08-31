using OrderManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepos { get; }
        IOrderTrackingRepository OrderTrackingRepos { get; }
        int Complete();
    }
}
