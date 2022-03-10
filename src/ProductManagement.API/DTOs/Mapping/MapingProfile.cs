using AutoMapper;
using Domain = ProductsManagement.Domain.Domain;

namespace ProductManagement.API.DTOs.Mapping
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Domain.Product, ProductCreateOrEditModel>().ReverseMap();
            CreateMap<Domain.Product, Product>().ForMember(p => p.Code , domain => domain.MapFrom(domain => domain.Id)).ReverseMap();
            CreateMap<Domain.Provider, ProviderCreateOrEditModel>().ReverseMap();
            CreateMap<Domain.Provider, Provider>().ForMember(p => p.Code, domain => domain.MapFrom(domain => domain.Id)).ReverseMap();
        }
    }
}
