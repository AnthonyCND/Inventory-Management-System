using AutoMapper;
using IMS.Domain.Entities;
using IMS.Infrastructure.EFModels;

namespace IMS.Infrastructure.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Domain → EF
            CreateMap<Supplier, SupplierEF>()
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Name)) ;

            // EF → Domain
            CreateMap<SupplierEF, Supplier>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplierId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SupplierName));

            CreateMap<Customer, CustomerEF>();
            CreateMap<CustomerEF, Customer>();
              
        }
    }
}
