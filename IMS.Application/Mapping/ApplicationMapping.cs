using AutoMapper;
using IMS.Application.DTOs;
using IMS.Domain.Entities;

namespace IMS.Application.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            // Domain → DTO
            CreateMap<Supplier, SupplierDTO>() ;

            // DTO → Domain
            CreateMap<SupplierDTO, Supplier>(); ;
        }
    }
}
