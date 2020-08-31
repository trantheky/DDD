using AutoMapper;
using OrderManagement.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Address, VMAddress>();            
            CreateMap<Domain.Order, VMOrder>();
            CreateMap<Domain.OrderLine, VMOrderLine>();            
            CreateMap<Domain.Product, VMProduct>();
            CreateMap<Domain.TransitLocation, VMTransitLocation>();            
        }
    }
}
